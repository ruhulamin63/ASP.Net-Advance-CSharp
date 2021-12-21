using BEL;
using Ghor_Sheba.Auth;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue(token);

            //***************************** revenue and bookings starts ************************************************//
            var bookings = new List<BookingModel>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBookings").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<BookingModel>>(AdminResponse);
            }
            var days = 0;
            var revenue_total = 0;
            var revenue_montly = 0;
            foreach (var v in bookings)
            {
                if(v.payment_status=="Paid")
                {
                    revenue_total += v.total_cost;
                }
              
                DateTime dt = v.order_date;
                var x = (DateTime.Now.Date - dt.Date).TotalDays;
                if (x <= 30)
                {
                    if (v.payment_status == "Paid")
                    {
                        revenue_montly += v.total_cost;
                    }
                    days++;
                }
            }

            double percentage = (double)days / (double)bookings.Count();
            percentage *= (double)100;

            double rp = revenue_montly / revenue_total;
            rp *= 100;

            TempData["total_bookings"] = bookings.Count();
            TempData["bookings_monthly"] = percentage;
            TempData["revenue_total"] = revenue_total;
            TempData["revenue_percent"] = rp;

            //***************************** revenue and bookings ends ************************************************//

            //***************************** customer count starts ************************************************//

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllCustomer").Result;
            var customers = new List<CustomerModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<CustomerModel>>(AdminResponse);
            }

            var cs_monthly = 0;

            foreach (var x in customers)
            {
                DateTime dt = x.created_at;
                var y = (DateTime.Now.Date - dt.Date).TotalDays;
                if (y <= 30)
                {
                    cs_monthly++;
                }
            }

            double cs_percentage = (double)cs_monthly / (double)customers.Count();
            cs_percentage *= (double)100;
            TempData["cs_percentage"] = cs_percentage;
            TempData["customers"] = customers.Count();
            //***************************** customer count ends ************************************************//

            //***************************** order count starts ************************************************//

            var orders_cancelled = 0;

            foreach (var x in bookings)
            {
                if (x.status == "Cancelled")
                {
                    orders_cancelled++;
                }
            }

            double order_percentage = (double)orders_cancelled / (double)bookings.Count();
            order_percentage *= (double)100;
            TempData["order_percentage"] = order_percentage;
            TempData["bookings"] = bookings.Count();

            //***************************** order count ends ************************************************//

            //***************************** service count starts ************************************************//

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBookingDetails").Result;
            var bt = new List<BookingDetailModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                bt = JsonConvert.DeserializeObject<List<BookingDetailModel>>(AdminResponse);
            }

            Dictionary<int, int> d = new Dictionary<int, int>();

            foreach (var x in bt)
            {
                if (d.ContainsKey(x.service_id))
                {
                    d[x.service_id]++;
                }
                else
                {
                    d[x.service_id] = 1;
                }
            }

            var services = new List<ServiceModel>();

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetServices").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<List<ServiceModel>>(AdminResponse);
            }

            var tp_list = new List<TopProductModel>();

            foreach (var x in services)
            {
                int co = 0;
                if (d.ContainsKey(x.id))
                {
                    co = d[x.id];
                }
                var tp = new TopProductModel()
                {
                    name = x.name,
                    category = x.category,
                    cnt = co
                };
                tp_list.Add(tp);
            }

            //***************************** service count ends ************************************************//

            return View(tp_list);
        }

        public ActionResult ViewCustomers()
        {
            var customers = new List<UserModel>();
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllCustomer").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }

            return View(customers);
        }

        public ActionResult AddCustomers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomers(CusUser u)
        {
            if (ModelState.IsValid)
            {
                u.usertype = "Customer";
                u.verification_status = "0";
                u.created_at = DateTime.Now;
                u.updated_at = DateTime.Now;

                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/AddCustomer", u).Result;
                if (response.IsSuccessStatusCode)
                {
                    var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                    var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                    if (success == 1)
                    {
                        TempData["SuccessMessage"] = "Successfully Created";
                        return RedirectToAction("ViewCustomers", "Admin");
                    }
                    else
                    {
                        //TempData["SuccessMessage"] = "User with Same email exists!";
                        return View(u);
                    }
                }
            }
            return View(u);
        }

        public ActionResult EditCustomer(int id)
        {
            var customers = new EditCustomerModel();
            string path = "api/Admin/CusUser/" + id;

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<EditCustomerModel>(AdminResponse);
            }
            return View(customers);
        }
        [HttpPost]
        public ActionResult EditCustomer(EditCustomerModel u)
        {
            if (ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Sucessfully Updated";

                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditCustomer", u).Result;
                return RedirectToAction("ViewCustomers", "Admin");
            }
            return View(u);
        }

        public ActionResult DeleteCustomer(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Admin/DeleteCustomer/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                if (success == 1)
                {
                    TempData["SuccessMessage"] = "Successfully Created";

                }
                else
                {
                    TempData["SuccessMessage"] = "Deletion Failed";

                }
            }
            return RedirectToAction("ViewCustomers", "Admin");
        }

        //******************************************Customer CRUD ends*********************************//

        //****************************************** Service Provider CRUD starts ************************//

        public ActionResult ViewServiceProviders()
        {
            var sp = new List<UserModel>();

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllServiceProvider").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }
            return View(sp);
        }

        public ActionResult AddServiceProviders()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddServiceProviders(ServUserModel u)
        {
            if (ModelState.IsValid)
            {
                u.usertype = "ServiceProvider";
                u.verification_status = "0";
                u.created_at = DateTime.Now;
                u.updated_at = DateTime.Now;

                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/AddServiceProvider", u).Result;
                if (response.IsSuccessStatusCode)
                {
                    var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                    var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                    if (success == 1)
                    {
                        TempData["AlertMessage"] = "Successfully Created";
                        return RedirectToAction("ViewServiceProviders", "Admin");
                    }
                    else
                    {
                        TempData["AlertMessage"] = "User with Same email exists!";
                        return View(u);
                    }
                }
            }
            return View(u);
        }

        public ActionResult EditServiceProvider(int id)
        {
            var sp = new EditServiceProviderModel();
            string path = "api/Admin/ServUser/" + id;

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<EditServiceProviderModel>(AdminResponse);
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult EditServiceProvider(EditServiceProviderModel u)
        {
            if (ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Sucessfully Updated";

                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditServiceProvider", u).Result;
                return RedirectToAction("ViewServiceProviders", "Admin");
            }
            return View(u);
        }

        public ActionResult DeleteServiceProvider(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Admin/DeleteServiceProvider/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                if (success == 1)
                {
                    TempData["SuccessMessage"] = "Successfully Deleted";

                }
                else
                {
                    TempData["SuccessMessage"] = "Deletion Failed";
                }
            }
            return RedirectToAction("ViewServiceProviders", "Admin");
        }

        //************************************************** Service Provider CRUD ends ****************************//

        //************************************************* Manager CRUD starts ***********************************//

        public ActionResult ViewManagers()
        {
            var managers = new List<UserModel>();

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllManager").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                managers = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }
            return View(managers);
        }

        public ActionResult AddManagers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddManagers(UserModel u)
        {
            if (ModelState.IsValid)
            {
                u.usertype = "Manager";
                u.verification_status = "0";
                u.created_at = DateTime.Now;
                u.updated_at = DateTime.Now;

                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/AddManager", u).Result;
                if (response.IsSuccessStatusCode)
                {
                    var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                    var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                    if (success == 1)
                    {
                        TempData["AlertMessage"] = "Successfully Created";
                        return RedirectToAction("ViewManagers", "Admin");
                    }
                    else
                    {
                        TempData["AlertMessage"] = "User with Same email exists!";
                        return View(u);
                    }
                }
            }
            return View(u);
        }

        public ActionResult EditManager(int id)
        {
            var managers = new EditUserModel();
            string path = "api/Admin/GetManager/" + id;

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                managers = JsonConvert.DeserializeObject<EditUserModel>(AdminResponse);
            }
            return View(managers);
        }
        [HttpPost]
        public ActionResult EditManager(EditUserModel u)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditManager", u).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AlertMessage"] = "Sucessfully Updated";
                    return RedirectToAction("ViewManagers", "Admin");
                }
            }
            TempData["AlertMessage"] = "Updation Failed";
            return View(u);
        }

        public ActionResult DeleteManager(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Admin/DeleteManager/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                if (success == 1)
                {
                    TempData["SuccessMessage"] = "Successfully Deleted";

                }
                else
                {
                    TempData["SuccessMessage"] = "Deletion Failed";
                }
            }
            return RedirectToAction("ViewManagers", "Admin");
        }

        //************************************************* Manager CRUD ends ***********************************//

        //************************************************ Service CRUD starts *********************************//

        public ActionResult ViewServices(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetServices/" + id).Result;
            var s = new List<ServiceModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<ServiceModel>>(AdminResponse);
            }
            return View(s);
        }

        public ActionResult AddServices()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddServices(ServiceModel s)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/AddServices", s).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Service Added";
                    return RedirectToAction("Index", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Failed Operation!";
            return View();
        }

        public ActionResult EditServices(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetService/" + id).Result;
            var s = new EditServiceModel();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<EditServiceModel>(AdminResponse);
            }
            //TempData["SuccessMessage"] = "Successfully Deleted";
            return View(s);
        }
        [HttpPost]
        public ActionResult EditServices(EditServiceModel s)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditServices", s).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Successfully Updated";
                    return RedirectToAction("ViewServices", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Updation Failed!";
            return RedirectToAction("ViewServices", "Admin");
        }

        public ActionResult DeleteServices(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Admin/DeleteServices/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                if (success == 1)
                {
                    TempData["SuccessMessage"] = "Successfully Deleted";

                }
                else
                {
                    TempData["SuccessMessage"] = "Deletion Failed";
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        //************************************************ Service CRUD ends *********************************//

        //************************************************ Bookings starts *********************************//

        public ActionResult ViewBookings()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBookings").Result;
            var b = new List<BookingModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                b = JsonConvert.DeserializeObject<List<BookingModel>>(AdminResponse);
            }
            return View(b);
        }

        public ActionResult EditBookings(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBooking/" + id).Result;
            var s = new BookingModel();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<BookingModel>(AdminResponse);
            }
            //TempData["SuccessMessage"] = "Successfully Deleted";
            return View(s);
        }

        [HttpPost]
        public ActionResult EditBookings(BookingModel b)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditBooking", b).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Successfully Updated";
                    return RedirectToAction("ViewBookings", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Updation Failed!";
            return View(b);
        }

        public ActionResult ViewBookingDetails(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBookingDetails/" + id).Result;
            var bd = new List<AdminBookingDetailModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                bd = JsonConvert.DeserializeObject<List<AdminBookingDetailModel>>(AdminResponse);
            }
            return View(bd);
        }

        //************************************************ Bookings ends *********************************//

        //************************************************ Coupons starts *********************************//

        public ActionResult ViewCoupons()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetCoupons").Result;
            var c = new List<CouponModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<List<CouponModel>>(AdminResponse);
            }
            return View(c);
        }

        public ActionResult AddCoupon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCoupon(CouponModel s)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/AddCoupon", s).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Coupon Added";
                    return RedirectToAction("ViewCoupons", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Operation Failed!";
            return View();
        }

        public ActionResult EditCoupon(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetCoupon/" + id).Result;
            var s = new CouponModel();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<CouponModel>(AdminResponse);
            }
            //TempData["SuccessMessage"] = "Successfully Deleted";
            return View(s);
        }

        [HttpPost]
        public ActionResult EditCoupon(CouponModel b)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/EditCoupon", b).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Successfully Updated";
                    return RedirectToAction("ViewCoupons", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Updation Failed!";
            return View(b);
        }

        public ActionResult DeleteCoupon(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Admin/DeleteCoupon/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<int>(SuccessResponse);
                if (success == 1)
                {
                    TempData["SuccessMessage"] = "Successfully Deleted";

                }
                else
                {
                    TempData["SuccessMessage"] = "Deletion Failed";
                }
            }
            return RedirectToAction("ViewCoupons", "Admin");
        }

        //************************************************ Coupons ends *********************************//

        //************************************************ Assign Service Provider Starts *********************************//

        public ActionResult ViewAvailableSP(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetSP").Result;
            var s = new List<ServiceProviderModel>();
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<ServiceProviderModel>>(AdminResponse);
            }
            Session["b_id"] = id;
            return View(s);
        }

        public ActionResult ConfirmBooking(int id)
        {
            var bs = new BookingServiceModel();
            bs.booking_id = Int32.Parse(Session["b_id"].ToString());
            bs.serviceprovider_id = id;

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Admin/ConfirmBooking", bs).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Booking Confirmed";
                return RedirectToAction("ViewBookings", "Admin");
            }
            TempData["SuccessMessage"] = "Operation Failed";
            return RedirectToAction("ViewBookings", "Admin");
        }

        //************************************************ Assign Service Provider ends *********************************//

        //************************************************ Print Starts *********************************//

        public ActionResult GetPrintCustomers(string token)
        {
           
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllCustomer").Result;

            var c = new List<UserModel>();

            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }

            return View(c);
        }
        public ActionResult PrintCustomers()
        {
            string token = Session["token"].ToString();
            var q = new ActionAsPdf("GetPrintCustomers", new { token = token });
            return q;
        }

        public ActionResult GetPrintSP(string token)
        {
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllServiceProvider").Result;
            var c = new List<UserModel>();

            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }

            return View(c);
        }
        public ActionResult PrintSP()
        {
            string token = Session["token"].ToString();
            var q = new ActionAsPdf("GetPrintSP", new { token = token });
            return q;
        }

        public ActionResult GetPrintManager(string token)
        {
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/AllManager").Result;
            var c = new List<UserModel>();

            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<List<UserModel>>(AdminResponse);
            }

            return View(c);
        }
        public ActionResult PrintManager()
        {
            string token = Session["token"].ToString();
            var q = new ActionAsPdf("GetPrintManager", new { token = token });
            return q;
        }

        public ActionResult GetPrintBDetail(string token, int id)
        {
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/GetBookingDetails/"+id.ToString()).Result;
            var c = new List<AdminBookingDetailModel>();

            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<List<AdminBookingDetailModel>>(AdminResponse);
            }

            var t_cost = 0;
            var b_id = id;
            foreach(var x in c)
            {
                t_cost += ((x.unit_price * x.quantity) - x.discount);
            }

            ViewData["t_cost"] = t_cost;
            ViewData["b_id"] = b_id;
            return View(c);
        }
        public ActionResult PrintBDetail(int id)
        {
            string token = Session["token"].ToString();
            var q = new ActionAsPdf("GetPrintBDetail", new { token = token ,id=id});
            return q;
        }

        //************************************************ Print ends *********************************//

        //************************************************ Salary Starts *********************************//

        public ActionResult ViewSalaries()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            var r = new List<UserSalariesModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/ViewSalaries").Result;
            if (response.IsSuccessStatusCode)
            {
                var AdminResponse = response.Content.ReadAsStringAsync().Result;
                r = JsonConvert.DeserializeObject<List<UserSalariesModel>>(AdminResponse);
            }
            return View(r);
        }

        public ActionResult PaySalary(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Admin/PaySalary/"+id.ToString()).Result;

            return RedirectToAction("ViewSalaries", "Admin");
        }


        //************************************************ Salary Ends *********************************//
    }
}
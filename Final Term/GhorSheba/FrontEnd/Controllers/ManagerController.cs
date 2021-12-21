using BEL;
using BEL.ManagerModel;
using DAL;
using FrontEnd.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [ManagerAccess]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserAllData()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var users = new List<UserModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/users/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersData = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserModel>>(usersData);
            }
            return View(users);
        }

        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserModel user)
        {
            //u.usertype = "Customer";
            //u.verification_status = "0";

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/users/create", user).Result;
                //return View(user);
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        public ActionResult UserEdit(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var user = new UserModel();
            string path = "api/users/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UserEdit(UserModel user)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
{
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/users/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        public ActionResult UserDelete(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/users/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        //================================================================================

        public ActionResult Customer_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var users = new List<CustomerModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/customer/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersData = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<CustomerModel>>(usersData);
            }
            return View(users);
        }

        //==========================Booking Confirm Function=========================================

        public ActionResult Booking_Confirm_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var booked = new List<BookingDetailModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/booking/confirm/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var bookingData = response.Content.ReadAsStringAsync().Result;
                booked = JsonConvert.DeserializeObject<List<BookingDetailModel>>(bookingData);
            }
            return View(booked);
        }

        public ActionResult Booking_Confirm_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booking_Confirm_Create(BookingDetailModel booked)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/booking/confirm/create", booked).Result;
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

        public ActionResult Booking_Confirm_Edit(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var user = new BookingDetailModel();
            string path = "api/booking/confirm/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<BookingDetailModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Booking_Confirm_Edit(BookingDetailModel user)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/booking/confirm/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

        public ActionResult Booking_Confirm_Delete(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/booking/confirm/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }


        //=======================Manage Booked Service============================

        public ActionResult Manage_Booked_Services()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var booked = new List<BookingModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/booking/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var bookingData = response.Content.ReadAsStringAsync().Result;
                booked = JsonConvert.DeserializeObject<List<BookingModel>>(bookingData);
            }
            return View(booked);
        }

        //==========================================================================
        public ActionResult ConfirmBookedService(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            Session["confirm_booked"] = id;

            var sp = new List<ServiceProviderModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/service/cbs/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var spData = response.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<List<ServiceProviderModel>>(spData);
            }
            return View(sp);
        }
        public ActionResult AssignServices(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var db = new ShebaDbEntities();

           /* var user = new Booking_Service();
            //string path = "api/users/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/assign/service/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<Booking_Service>(Response);
            }*/

            string id1 = Session["confirm_booked"].ToString();

            var cs = new Booking_Service()
            {
                booking_id = Int32.Parse(id1),
                serviceprovider_id = id
            };

            var book = (from data in db.Bookings
                        where data.id == cs.booking_id
                        select data).FirstOrDefault();

            var temp = book;
            temp.status = "confirm";
            db.Entry(book).CurrentValues.SetValues(temp);
            db.SaveChanges();

            db.Booking_Service.Add(cs);
            db.SaveChanges();

            var sp = (from data in db.ServiceProviders
                      where data.id == id
                      select data).First();
            sp.work_status = "busy";
            db.SaveChanges();

            return RedirectToAction("Manage_Booked_Services", "Manager");
        }

        //==========================Services Function=========================================

        public ActionResult Service_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var service = new List<ServiceModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/service/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var serviceData = response.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<List<ServiceModel>>(serviceData);
            }
            return View(service);
        }

        public ActionResult Service_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Service_Create(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                string token = Session["token"].ToString();
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/service/create", service).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Create Successfully";
                    return RedirectToAction("ViewCoupons", "Admin");
                }
            }
            TempData["SuccessMessage"] = "Some data missing !";
            return View();
        }

        public ActionResult Service_Edit(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var user = new ServiceModel();
            string path = "api/service/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<ServiceModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Service_Edit(ServiceModel user)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/service/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("Service_List", "Manager");
        }

        public ActionResult Service_Delete(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/service/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("Service_List", "Manager");
        }


        //===================Complain Function=======================================

        public ActionResult Review_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var review = new List<ReviewModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/review/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var reviewData = response.Content.ReadAsStringAsync().Result;
                review = JsonConvert.DeserializeObject<List<ReviewModel>>(reviewData);
            }
            return View(review);
        }


        //=============================Service Provider Function========================

        public ActionResult Service_Provider_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var service = new List<ServiceProviderModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/service/provider/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var serviceData = response.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<List<ServiceProviderModel>>(serviceData);
            }
            return View(service);
        }

        public ActionResult Service_Provider_Get_Id(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var user = new ServiceProviderModel();
            //string path = "api/service/provider/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/service/provider/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<ServiceProviderModel>(Response);
            }
            return View(user);
        }

        //====================================Profile===================================

        public ActionResult Coupon_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);


            var copon = new List<CouponModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/coupon/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var coponData = response.Content.ReadAsStringAsync().Result;
                copon = JsonConvert.DeserializeObject<List<CouponModel>>(coponData);
            }
            return View(copon);
        }


        //===================================================================================

        public ActionResult Salary_List()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var copon = new List<SalariesModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/salary/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var coponData = response.Content.ReadAsStringAsync().Result;
                copon = JsonConvert.DeserializeObject<List<SalariesModel>>(coponData);
            }
            return View(copon);
        }

        public ActionResult Salary_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Salary_Create(int id, SalariesModel salaries)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/salary/create/" + id.ToString(), salaries).Result;
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Salary_List", "Manager");
        }

        //===================================================================================
       
        public ActionResult Setting_Overview()
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            //string id = Session["id"].ToString();

            var user = new UserModel();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/users/" + 12).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserModel>(Response);
            }
            return View(user);
        }

        public ActionResult Setting_Update(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var user = new UserModel();
            //string path = "api/service/" + id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/users/" + 12).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Setting_Update(UserModel user)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/users/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("Setting_Update", "Manager");
        }

        [HttpGet]
        public ActionResult Create_Image()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Image(ProfileModel imageModel)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Views/Manager/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
           // var path = imageModel.ToString();

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var image = new ProfilePicture()
                {
                    user_id = 14,
                   // image = imageModel,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                };

                db.ProfilePictures.Add(image);
                // db.ProfilePictures.Add(image);
                db.SaveChanges();
            }
            ModelState.Clear();

            return RedirectToAction("Setting_Overview");
        }
    }
}
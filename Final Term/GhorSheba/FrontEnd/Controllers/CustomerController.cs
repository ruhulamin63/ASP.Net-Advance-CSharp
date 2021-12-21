using BEL;
using FrontEnd.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [CustomerAccess]
    public class CustomerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            string token = Session["token"].ToString();

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            int id = Int32.Parse(Session["u_id"].ToString());
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CusUser/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var cus = JsonConvert.DeserializeObject<CusProfileModel>(Response);
                return View(cus);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Profile(CusProfileModel u)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
        

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Customer/EditProfile", u).Result;

            return View(u);
        }

        public ActionResult ViewBooking()
        {
            int id = Int32.Parse(Session["u_id"].ToString());

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CusUser/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var cus = JsonConvert.DeserializeObject<CusProfileModel>(Response);

                HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("api/Customer/GetBooking/" + cus.id).Result;

                if (response1.IsSuccessStatusCode)
                {
                    var Response1 = response1.Content.ReadAsStringAsync().Result;
                    var b = JsonConvert.DeserializeObject<List<BookingModel>>(Response1);
                    return View(b);
                }
            }
            return RedirectToAction("Profile", "Customer");
        }

        public ActionResult BookingDetail(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/GetDetail/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var b = JsonConvert.DeserializeObject<List<CusBookingDetailModel>>(Response);
                return View(b);
            }
            return RedirectToAction("ViewBooking", "Customer");
        }

        public ActionResult CancelBooking(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CancelBooking/"+id).Result;

            return RedirectToAction("ViewBooking", "Customer");
        }

        public ActionResult Checkout()
        {
            var d = JsonConvert.DeserializeObject<List<CartModel>>(Session["cart"].ToString());


            int id = Int32.Parse(Session["u_id"].ToString());

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CusUser/" + id.ToString()).Result;
            var cus = new CusProfileModel();

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                cus = JsonConvert.DeserializeObject<CusProfileModel>(Response);
            }

            var c = new List<CusBookingModel>();

            foreach(var x in d)
            {
                var temp = new CusBookingModel()
                {
                    id=cus.id,
                    s_id=x.s_id,
                    user_id=cus.user_id,
                    name=x.name,
                    category=x.category,
                    quantity=x.quantity,
                    unit_price=x.unit_price,
                    total_cost=x.total_cost
                };
                c.Add(temp);
            }

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Customer/Checkout", c).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewBooking", "Customer");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewAvailableCoupons(int id)
        {
            string token = Session["token"].ToString();
            int u_id = Int32.Parse(Session["u_id"].ToString());
            Session["b_id"] = id;
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CusUser/" + u_id.ToString()).Result;
            var cou = new List<CouponModel>();

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var cus = JsonConvert.DeserializeObject<CusProfileModel>(Response);
               
                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                var response1 = GlobalVariables.WebApiClient.GetAsync("api/Customer/AvailableCoupon/" + cus.id.ToString()).Result;
                if(response1.IsSuccessStatusCode)
                {
                    var Response1 = response1.Content.ReadAsStringAsync().Result;
                    var temp = JsonConvert.DeserializeObject<List<CouponModel>>(Response1);

                    GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                    HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("api/Customer/GetBookingById/" + id.ToString()).Result;
                    if(response2.IsSuccessStatusCode)
                    {
                        var Response2 = response2.Content.ReadAsStringAsync().Result;
                        var b = JsonConvert.DeserializeObject<BookingModel>(Response2);

                        foreach(var x in temp)
                        {
                            if(b.total_cost>=x.min_order_amount)
                            {
                                cou.Add(x);
                            }
                        }
                    }
                }
            }

            return View(cou);
        }

        public ActionResult ApplyCoupon(int id)
        {
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            int b_id = Int32.Parse(Session["b_id"].ToString());
            int u_id = Int32.Parse(Session["u_id"].ToString());

            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Customer/CusUser/" + u_id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var c = JsonConvert.DeserializeObject<CusProfileModel>(Response);

                var temp = new CustomerCouponModel()
                {
                    booking_id = b_id,
                    customer_id = c.id,
                    coupon_id = id,
                    used_count = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Customer/ApplyToken", temp).Result;

            }
            return RedirectToAction("ViewBooking", "Customer");
        }

    }
}
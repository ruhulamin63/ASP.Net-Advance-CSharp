using BEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewServices(int id)
        {
            var s = new List<ServiceModel>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Home/GetServices/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                s = JsonConvert.DeserializeObject<List<ServiceModel>>(Response);
            }
            return View(s);
        }

        public ActionResult AddToCart(int id)
        {
            string path = "api/Home/GetService/" + id.ToString();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                var s = JsonConvert.DeserializeObject<ServiceModel>(Response);

                if (Session["cart"] == null)
                {
                    var x = new CartModel()
                    {
                        id = s.id,
                        s_id = id,
                        name = s.name,
                        category = s.category,
                        unit_price = s.unit_price,
                        quantity = 1,
                        total_cost = (s.unit_price - s.discount_amount)
                    };
                    var l = new List<CartModel>();
                    l.Add(x);
                    string json = JsonConvert.SerializeObject(l);
                    Session["cart"] = json;
                }
                else
                {
                    var x = new CartModel()
                    {
                        id = s.id,
                        name = s.name,
                        s_id = id,
                        category = s.category,
                        unit_price = s.unit_price,
                        quantity = 1,
                        total_cost = (s.unit_price - s.discount_amount)
                    };
                    var l = JsonConvert.DeserializeObject<List<CartModel>>(Session["cart"].ToString());
                    var temp = new List<CartModel>();

                    int f = 0;

                    foreach (var y in l)
                    {
                        if (y.id == s.id)
                        {
                            y.quantity++;
                            y.total_cost += (s.unit_price - s.discount_amount);
                            f = 1;
                        }
                        temp.Add(y);
                    }

                    if (f == 0)
                    {
                        temp.Add(x);
                    }

                    string json = JsonConvert.SerializeObject(temp);
                    Session["cart"] = json;
                }

                if (s.category == "HomeCleaning")
                {
                    return RedirectToAction("ViewServices/1", "Home");
                }
                else if (s.category == "ApplianceRepair")
                {
                    return RedirectToAction("ViewServices/2", "Home");
                }
                else if (s.category == "PestControl")
                {
                    return RedirectToAction("ViewServices/3", "Home");
                }
                else if (s.category == "ApplianceMaintainance")
                {
                    return RedirectToAction("ViewServices/5", "Home");
                }
                else if (s.category == "Plumbing")
                {
                    return RedirectToAction("ViewServices/4", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewCart()
        {
            if (Session["cart"] != null)
            {
                var d = JsonConvert.DeserializeObject<List<CartModel>>(Session["cart"].ToString());

                return View(d);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteFromCart(int id)
        {
            var d = JsonConvert.DeserializeObject<List<CartModel>>(Session["cart"].ToString());
            var temp = new List<CartModel>();
            foreach (var x in d)
            {
                if (x.id == id)
                {
                    if (x.quantity > 1)
                    {
                        string path = "api/Home/GetService/" + id.ToString();
                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var Response = response.Content.ReadAsStringAsync().Result;
                            var s = JsonConvert.DeserializeObject<ServiceModel>(Response);
                            x.quantity--;
                            x.total_cost -= (s.unit_price - s.discount_amount);
                            temp.Add(x);
                        }
                    }
                }
                else
                {
                    temp.Add(x);
                }
            }
            string json = JsonConvert.SerializeObject(temp);
            Session["cart"] = json;
            return RedirectToAction("ViewCart", "Home");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(string fullname, string email, string password, string Confirmpassword,
            string phone, string address)
        {
            if (password != Confirmpassword)
            {
                return View();
            }

            var cm = new CusUser()
            {
                fullname = fullname,
                email = email,
                password = password,
                phone = phone,
                address = address
            };

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Home/AddCustomer", cm).Result;


            return RedirectToAction("Index", "Customer");
        }

    }
}
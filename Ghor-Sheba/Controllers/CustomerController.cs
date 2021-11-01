using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Ghor_Sheba.Auth;
using Ghor_Sheba.Models;
using Newtonsoft.Json;

namespace Ghor_Sheba.Controllers
{
    [CustomerAccess]
    public class CustomerController : Controller
    {
        // GET: Customer

        public ActionResult Index()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            return View();
        }
        [AllowAnonymous]
        public ActionResult AddToCart(int id)
        {
            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                        where data.id == id
                        select data).FirstOrDefault();


            if (Session["cart"] == null)
            {
                List<Service> s = new List<Service>();
                s.Add(serv);
                string json = JsonConvert.SerializeObject(s);
                Session["cart"] = json;
            }
            else
            {
                var d = JsonConvert.DeserializeObject<List<Service>>(Session["cart"].ToString());
                int f = 0;

                foreach(var p in d)
                {
                    if(p.id==id)
                    {
                        f = 1;
                        break;
                    }
                }

                if (f==0) 
                {
                    d.Add(serv);
                    string json = JsonConvert.SerializeObject(d);
                    Session["cart"] = json;
                }
                else
                {
                    string json = JsonConvert.SerializeObject(d);
                    Session["cart"] = json;
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult ViewCart()
        {
            if (Session["cart"] != null)
            {
                var d = JsonConvert.DeserializeObject<List<Service>>(Session["cart"].ToString());
                return View(d);
            }
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult DeleteFromCart(int id)
        {
            if (Session["cart"] != null) {
                var d = JsonConvert.DeserializeObject<List<Service>>(Session["cart"].ToString());
                List<Service> s = new List<Service>();
                int co = 0;

                foreach(var p in d)
                {
                    if(p.id!=id)
                    {
                        co++;
                        s.Add(p);
                    }
                }

                if(co>0)
                {
                    string json = JsonConvert.SerializeObject(s);
                    Session["cart"] = json;
                }
                else
                {
                    Session["cart"] = null; 
                }
            return RedirectToAction("ViewCart", "Customer");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Checkout()
        {
            var d = JsonConvert.DeserializeObject<List<Service>>(Session["cart"].ToString());
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            int c = 0;
            foreach(var p in d)
            {
                int co = (int)p.cost;
                c += co;
            }

            Booking b = new Booking()
            {
                customer_id = user.id,
                cost = c,
                status = "pending",
                payment_status = "pending"
            };

            var db = new ShebaDbEntities();
            db.Bookings.Add(b);
            db.SaveChanges();

            foreach(var p in d)
            {
                Booking_details bd = new Booking_details()
                {
                    service_id = p.id,
                    booking_id = b.id
                };
                db.Booking_details.Add(bd);
                db.SaveChanges();
            }
            Session.Remove("cart");
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Signup(string Fullname, string Email, string Username, string Password, string Confirmpassword,
            string Number, string Address)
        {
            if (Password != Confirmpassword)
            {
                return View();
            }

            var db = new ShebaDbEntities();
            var Usertype = "Customer";
            var Status = "unblocked";

            LoginUser newUser = new LoginUser()
            {
                fullname = Fullname,
                email = Email,
                username = Username,
                password = Password,
                phone = Number,
                address = Address,
                user_type = Usertype,
                status = Status
            };
            db.LoginUsers.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Login", "Login");
        }



        public ActionResult Profile()
        {
            var db = new ShebaDbEntities();
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            ViewData["password"] = user.password;
            ViewData["phone"] = user.phone;
            ViewData["address"] = user.address;
            return View();
        }


        [HttpPost]
        public ActionResult Profile(string username, string password, string phone, string address)
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            var db = new ShebaDbEntities();
            var res = (from u in db.LoginUsers
                       where u.id == user.id
                       select u).FirstOrDefault();

            res.username = username;
            res.password = password;
            res.phone = phone;
            res.address = address;
            db.SaveChanges();
            FormsAuthentication.SignOut();
            string json = JsonConvert.SerializeObject(res);
            FormsAuthentication.SetAuthCookie(json, true);
            ViewData["username"] = res.username;
            ViewData["password"] = res.password;
            ViewData["phone"] = res.phone;
            ViewData["address"] = res.address;
            return View();
        }


        public ActionResult MakeComplaint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeComplaint(string descriptions)
        {
            var db = new ShebaDbEntities();
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());

            Complaint comp = new Complaint()
            {
                customer_id = user.id,
                description = descriptions,
                status = "pending"
            };
            db.Complaints.Add(comp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
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

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();

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
            var em = User.Identity.Name;
            em = em.Trim();

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
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
            Fullname = Fullname.Trim();
            Email = Email.Trim();
            Username = Username.Trim();
            Password = Password.Trim();
            Confirmpassword = Confirmpassword.Trim();
            Number = Number.Trim();
            Address = Address.Trim();

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
            var em = User.Identity.Name;
           
            var db = new ShebaDbEntities();
            var res = (from d in db.LoginUsers
                       where d.email == em
                       select d).FirstOrDefault();
            ViewData["username"] = res.username;
            return View(res);
        }
        [HttpPost]
        public ActionResult Profile(LoginUser u)
        {
            if (u.username != "" && u.username != null)
                u.username = u.username.Trim();
            if (u.phone != "" && u.phone != null)
                u.phone = u.phone.Trim();
            if (u.address != "" && u.address != null)
                u.address = u.address.Trim();
            if (u.fullname != "" && u.fullname != null)
                u.fullname = u.fullname.Trim();
            if (u.password != "" && u.password != null)
                u.password = u.password.Trim();

            if (u.username == "" || u.fullname == "" || u.password == "" || u.address == "" || u.phone == "")
            {
                return View(u);
            }
            var data = User.Identity.Name;

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from d in db.LoginUsers
                              where d.id == u.id
                              select d).FirstOrDefault();



                entity.username = u.username.Trim();
                entity.phone = u.phone.Trim();
                entity.address = u.address.Trim();
                entity.fullname = u.fullname.Trim();
                entity.password = u.password.Trim();

                db.SaveChanges();

            }
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(u.email, true);
            ViewData["username"] = u.username;
            return View(u);
        }


        public ActionResult MakeComplaint()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View();
        }

        [HttpPost]
        public ActionResult MakeComplaint(string descriptions)
        {
            if (descriptions != null)
                descriptions = descriptions.Trim();
            if(descriptions==null || descriptions=="")
            {
                return View();
            }
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            Complaint comp = new Complaint()
            {
                customer_id = user.id,
                description = descriptions,
                status = "unread"
            };
            ViewData["username"] = user.username;
            db.Complaints.Add(comp);
            db.SaveChanges();

            return RedirectToAction("Profile", "Customer");
        }

        public ActionResult ViewBooking()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var b = (from d in db.Bookings
                     where d.customer_id == user.id
                     select d).ToList();

            return View(b);
        }

        public ActionResult ViewDetails(int id)
        {
            var db = new ShebaDbEntities();

            var bd = (from data in db.Booking_details
                      where data.booking_id == id
                      select data).ToList();
            var slist = new List<Service>();
            
            foreach(var p in bd)
            {
                var x = (from data in db.Services
                         where data.id == p.service_id
                         select data).FirstOrDefault();
                slist.Add(x);
            }

            var em = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View(slist);
        }
    }
}
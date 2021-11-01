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
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var m = (from d in db.LoginUsers
                     where d.user_type == "Manager"
                     select d).ToList();
            ViewData["managers"] = m.Count();

            var c = (from d in db.LoginUsers
                     where d.user_type == "Customer"
                     select d).ToList();
            ViewData["customers"] = c.Count();

            var sp = (from d in db.LoginUsers
                     where d.user_type == "ServiceProvider"
                     select d).ToList();
            ViewData["sp"] = sp.Count();

            var u = (from d in db.LoginUsers
                     where d.id > 0
                     select d).ToList();
            return View(u);
        }


        public ActionResult Profile()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();
            var res = (from d in db.LoginUsers
                       where d.id == user.id
                       select d).FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        public ActionResult Profile(LoginUser u)
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from d in db.LoginUsers
                              where d.id == u.id
                              select d).FirstOrDefault();



                entity.username = u.username.Trim();
                entity.phone = u.phone.Trim();
                //entity.email = user.email.Trim();
                entity.address = u.address.Trim();
                entity.fullname = u.fullname.Trim();
                //entity.user_type = user.user_type.Trim();
                entity.password = u.password.Trim();
                entity.address = u.address.Trim();

                db.SaveChanges();
                return View(u);
            }
            FormsAuthentication.SignOut();
            string json = JsonConvert.SerializeObject(u);
            FormsAuthentication.SetAuthCookie(json, true);
            ViewData["username"] = u.username;
            return View(user);
        }
        // Manage Part begins
        public ActionResult ManageManager()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();

            var managers = (from d in db.LoginUsers
                            where d.user_type == "Manager"
                            select d).ToList();

            return View(managers);
        }

        public ActionResult ManageCustomer()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();

            var customers = (from d in db.LoginUsers
                             where d.user_type == "Customer"
                             select d).ToList();

            return View(customers);
        }

        public ActionResult ManageServiceProvider()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();

            var ServiceProviders = (from d in db.LoginUsers
                                    where d.user_type == "ServiceProvider"
                                    select d).ToList();

            return View(ServiceProviders);
        }
        // Manage Part ends
        // Add part begins
        public ActionResult AddManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddManager(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                var db = new ShebaDbEntities();
                user.user_type = "Manager";
                user.status = "unblocked";

                var temp = (from td in db.LoginUsers
                            where td.email == user.email
                            select td).FirstOrDefault();

                if (temp == null)
                {
                    db.LoginUsers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("ManageManager", "Admin");
                }
                else
                {
                    ViewData["message"] = "User with this email already exists";
                    return View(user);
                }
            }
            return View(user);
        }

        public ActionResult AddCustomer()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(LoginUser user)
        {
                var db = new ShebaDbEntities();
                user.user_type = "Customer";

                var temp = (from td in db.LoginUsers
                            where td.email == user.email
                            select td).FirstOrDefault();

                if (temp == null)
                {
                    db.LoginUsers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("ManageCustomer", "Admin");
                }
                else
                {
                    ViewData["message"] = "User with this email already exists";
                    return View(user);
                }

        }

        public ActionResult AddServiceProvider()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            return View();
        }
        [HttpPost]
        public ActionResult AddServiceProvider(LoginUser user)
        {
            user.user_type = "ServiceProvider";
            if (ModelState.IsValid)
            {
                var db = new ShebaDbEntities();
                user.user_type = "ServiceProvider";
                user.status = "unblocked";

                var temp = (from td in db.LoginUsers
                            where td.email == user.email
                            select td).FirstOrDefault();

                if (temp == null)
                {
                    db.LoginUsers.Add(user);
                    db.SaveChanges();

                    var d = (from data in db.LoginUsers
                             where data.email == user.email
                             select data).FirstOrDefault();
                    var a = new service_provider_status()
                    {
                        service_provider_id = d.id,
                        status = "available"
                    };

                    db.service_provider_status.Add(a);
                    db.SaveChanges();

                    return RedirectToAction("ManageServiceProvider", "Admin");
                }
                else
                {
                    ViewData["message"] = "User with this email already exists";
                    return View(user);
                }
            }
            return View(user);
        }

        // Add part ends

        // Delete Part begins

        public ActionResult DeleteManager(int id)
        {
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;
            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteManager(LoginUser user)
        {
            var db = new ShebaDbEntities();
            var manager = (from data in db.LoginUsers
                           where data.id == user.id
                           select data).FirstOrDefault();
            db.LoginUsers.Remove(manager);
            db.SaveChanges();
            return RedirectToAction("ManageManager", "Admin");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(LoginUser user)
        {
            var db = new ShebaDbEntities();
            var customer = (from data in db.LoginUsers
                           where data.id == user.id
                           select data).FirstOrDefault();

            var book = (from data in db.Bookings
                        where data.customer_id == user.id
                        select data).ToList();

            foreach(var bt in book)
            {
                var bookdt = (from data in db.Booking_details
                              where data.booking_id == bt.id
                              select data).ToList();
                foreach(var x in bookdt)
                {
                    db.Booking_details.Remove(x);
                    db.SaveChanges();
                }
            }

            foreach(var x in book)
            {
                db.Bookings.Remove(x);
                db.SaveChanges();
            }
            db.LoginUsers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("ManageCustomer", "Admin");
        }

        public ActionResult DeleteServiceProvider(int id)
        {
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteServiceProvider(LoginUser user)
        {
            var db = new ShebaDbEntities();
            var sp = (from data in db.LoginUsers
                            where data.id == user.id
                            select data).FirstOrDefault();

            var bookcf = (from data in db.Booking_confirms
                          where data.service_provider_id == user.id
                          select data).ToList();

            var spst = (from data in db.service_provider_status
                        where data.service_provider_id == user.id
                        select data).ToList();

            foreach(var x in spst)
            {
                db.service_provider_status.Remove(x);
                db.SaveChanges();
            }


            foreach (var x in bookcf)
            {
                db.Booking_confirms.Remove(x);
                db.SaveChanges();
            }

            db.LoginUsers.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("ManageServiceProvider", "Admin");
        }

        // Delete Part ends

        // Edit Part begins
        public ActionResult EditManager(int id)
        {
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult EditManager(LoginUser user)
        {
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                //entity.email = user.email.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                //entity.user_type = user.user_type.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();
                return View(user);
            }
        }

        public ActionResult EditCustomer(int id)
        {
            
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult EditCustomer(LoginUser user)
        {
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                //entity.email = user.email.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                //entity.user_type = user.user_type.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();
                return View(user);
            }

        }

        public ActionResult EditServiceProvider(int id)
        {
            var d = User.Identity.Name;
            var u = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = u.username;

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult EditServiceProvider(LoginUser user)
        {
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                //entity.email = user.email.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                //entity.user_type = user.user_type.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();
                return View(user);
            }
        }

        // Edit Part Ends

        //..........................................................................// Service Part starts

        public ActionResult ManageService()
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                        where data.id > 0
                        select data).ToList();
            return View(serv);
        }

        public ActionResult EditService(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();
            var s = (from data in db.Services
                        where data.id == id
                        select data).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult EditService(Service s)
        {
            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                      where data.id == s.id
                      select data).FirstOrDefault();
            db.Entry(serv).CurrentValues.SetValues(s);
            db.SaveChanges();
            return View();
        }

        public ActionResult AddService()
        {
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service s)
        {
            if (ModelState.IsValid)
            {
                var db = new ShebaDbEntities();

                var temp = (from td in db.Services
                            where td.name == s.name
                            select td).FirstOrDefault();

                if (temp == null)
                {
                    db.Services.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("ManageService", "Admin");
                }
                else
                {
                    ViewData["message"] = "Service already exists";
                    return View(s);
                }
            }
            return View(s);
        }

        public ActionResult DeleteService(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                        where data.id == id
                        select data).FirstOrDefault();

            return View(serv);
        }
        [HttpPost]
        public ActionResult DeleteService(Service s)
        {
            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                      where data.id == s.id
                      select data).FirstOrDefault();
            db.Services.Remove(serv);
            db.SaveChanges();
            return RedirectToAction("ManageService", "Admin");
        }

        //.....................................................................// Service Part ends

        //......................................................................// Complain Part starts
        public ActionResult ManageComplain()
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var comp = (from data in db.Complaints
                        where data.id > 0
                        select data).ToList();
            return View(comp);
        }

        public ActionResult EditComplain(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var comp = (from data in db.Complaints
                        where data.id == id
                        select data).FirstOrDefault();
            return View(comp);
        }
        [HttpPost]
        public ActionResult EditComplain(Complaint c)
        {
            var db = new ShebaDbEntities();
            var comp = (from data in db.Complaints
                        where data.id == c.id
                        select data).FirstOrDefault();
            db.Entry(comp).CurrentValues.SetValues(c);
            db.SaveChanges();
            return View();
        }

        public ActionResult ManageBookedService()
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var booking = (from data in db.Bookings
                        where data.status=="pending"
                        select data).ToList();
            return View(booking);
        }

        public ActionResult ConfirmBookedService(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var sp = (from data in db.service_provider_status
                           where data.status == "available"
                           select data).ToList();
            Session["confirm_booking"] = id;
            return View(sp);
        }

        public ActionResult DeleteBookedService(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();
            var book = (from data in db.Bookings
                        where data.id == id
                        select data).FirstOrDefault();

            var bookdt = (from data in db.Booking_details
                          where data.booking_id == id
                          select data).ToList();

            foreach(var p in bookdt)
            {
                db.Booking_details.Remove(p);
                db.SaveChanges();
            }

            db.Bookings.Remove(book);
            db.SaveChanges();

            return RedirectToAction("ManageService", "Admin");
        }
        /*[HttpPost]
        public ActionResult DeleteBookedService(Booking b)
        {
            var d = User.Identity.Name;
            var user = new JavaScriptSerializer().Deserialize<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();

            var book = (from data in db.Bookings
                            where data.id == b.id
                            select data).FirstOrDefault();

            var bc = (from data in db.Booking_confirms
                      where data.id == b.id
                      select data).FirstOrDefault();

            db.Booking_confirms.Remove(bc);
            db.SaveChanges();

            db.Bookings.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ManageService", "Admin");
        }*/

        public ActionResult EditBookedService(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();

            var book = (from data in db.Bookings
                        where data.id == id
                        select data).FirstOrDefault();

            return View(book);
        }
        [HttpPost]
        public ActionResult EditBookedService(Booking b)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();

            var book = (from data in db.Bookings
                        where data.id == b.id
                        select data).FirstOrDefault();

            db.Entry(book).CurrentValues.SetValues(b);
            db.SaveChanges();
            return View(book);
        }

        public ActionResult AssignServiceProvider(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();
            string id1 = Session["confirm_booking"].ToString();

            var cs = new Booking_confirms()
            {
                booking_id = Int32.Parse(id1),
                service_provider_id = id,
                status = "confirm"
            };

            var book = (from data in db.Bookings
                        where data.id == cs.booking_id
                        select data).FirstOrDefault();

            var temp = book;
            temp.status = "confirm";
            db.Entry(book).CurrentValues.SetValues(temp);
            db.SaveChanges();
            db.Booking_confirms.Add(cs);
            db.SaveChanges();

            return RedirectToAction("ManageBookedService", "Admin");
        }

        public ActionResult PaymentStatus()
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;

            var db = new ShebaDbEntities();

            var payment = (from data in db.Bookings
                           where data.id > 0
                           select data).ToList();

            return View(payment);
        }

        public ActionResult PaymentUpdate(int id)
        {
            var d = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(d.ToString());
            ViewData["username"] = user.username;
            var db = new ShebaDbEntities();

            var payment = (from data in db.Bookings
                           where data.id == id
                           select data).FirstOrDefault();
            Session["payment_id"] = id;
            return View(payment);
        }
        [HttpPost]
        public ActionResult PaymentUpdate(int cost, string payment_status)
        {
            var db = new ShebaDbEntities();
            int id = Int32.Parse(Session["payment_id"].ToString());
            var booking = (from data in db.Bookings
                           where data.id == id
                           select data).FirstOrDefault();
            booking.cost = cost;
            booking.payment_status = payment_status;

            db.Entry(booking).CurrentValues.SetValues(booking);
            db.SaveChanges();

            return RedirectToAction("PaymentStatus", "Admin");
        }

    }
}
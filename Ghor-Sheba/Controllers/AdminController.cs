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
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            
            var m = (from d in db.LoginUsers
                     where d.user_type.Trim() == "Manager"
                     select d).ToList();
            ViewData["managers"] = m.Count();

            var c = (from d in db.LoginUsers
                     where d.user_type.Trim() == "Customer"
                     select d).ToList();
            ViewData["customers"] = c.Count();

            var sp = (from d in db.LoginUsers
                     where d.user_type.Trim() == "ServiceProvider"
                     select d).ToList();
            ViewData["sp"] = sp.Count();

            var u = (from d in db.LoginUsers
                     where d.id > 0
                     select d).ToList();
            return View(u);
        }


        public ActionResult Profile()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            
            var res = (from d in db.LoginUsers
                       where d.id == user.id
                       select d).FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        public ActionResult Profile(LoginUser u)
        {
            if(u.username!="" && u.username!=null)
                u.username = u.username.Trim();
            if(u.phone!="" && u.phone != null)
                u.phone = u.phone.Trim();
            if(u.address!="" && u.address!=null)
                u.address = u.address.Trim();
            if(u.fullname!="" && u.fullname!=null)
                u.fullname = u.fullname.Trim();
            if(u.password!="" && u.password!=null)
                u.password = u.password.Trim();

            if (u.username==null || u.fullname==null || u.password==null || u.phone==null || u.address==null ||  u.username == "" || u.fullname == "" || u.password == "" || u.address == "" || u.phone == "")
            {
                return View(u);
            }
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
                ViewData["username"] = entity.username;
            }


            
            return View(u);
        }
        // Manage Part begins
        public ActionResult ManageManager()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            
            var managers = (from d in db.LoginUsers
                            where d.user_type.Trim() == "Manager"
                            select d).ToList();

            return View(managers);
        }

        public ActionResult ManageCustomer()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var customers = (from d in db.LoginUsers
                             where d.user_type.Trim() == "Customer"
                             select d).ToList();

            return View(customers);
        }

        public ActionResult ManageServiceProvider()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var ServiceProviders = (from d in db.LoginUsers
                                    where d.user_type.Trim() == "ServiceProvider"
                                    select d).ToList();

            return View(ServiceProviders);
        }
        // Manage Part ends
        // Add part begins
        public ActionResult AddManager()
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
        public ActionResult AddManager(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                user.status = user.status.Trim();
                if(user.status== "Select status")
                {
                    return View();
                }
                user.user_type = "Manager";
                using (ShebaDbEntities db = new ShebaDbEntities())
                {
                    var em = User.Identity.Name;
                    em = em.Trim();

                    var u = (from data in db.LoginUsers
                                where data.email.Trim() == em
                                select data).FirstOrDefault();
                    ViewData["username"] = u.username;
                    var entity = (from d in db.LoginUsers
                                  where d.email.Trim() == user.email.Trim()
                                  select d).FirstOrDefault();

                    if (entity == null)
                    {
                        var newuser = new LoginUser()
                        {
                            fullname = user.fullname.Trim(),
                            username = user.username.Trim(),
                            password = user.password.Trim(),
                            email = user.email.Trim(),
                            address = user.address.Trim(),
                            phone = user.phone.Trim(),
                            user_type = user.user_type.Trim(),
                            status = user.status
                        };
                        db.LoginUsers.Add(newuser);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewData["message"] = "User Name already exisits";
                        return View();
                    }
                    return RedirectToAction("ManageManager", "Admin");
                }
            }
            return View(user);

        }

        public ActionResult AddCustomer()
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
        public ActionResult AddCustomer(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                user.user_type = "Customer";
                using (ShebaDbEntities db = new ShebaDbEntities())
                {
                    var em = User.Identity.Name;
                    em = em.Trim();

                    var u = (from data in db.LoginUsers
                             where data.email.Trim() == em
                             select data).FirstOrDefault();
                    ViewData["username"] = u.username;
                    var entity = (from d in db.LoginUsers
                                  where d.email.Trim() == user.email.Trim()
                                  select d).FirstOrDefault();

                    if (entity == null)
                    {
                        var newuser = new LoginUser()
                        {
                            fullname = user.fullname.Trim(),
                            username = user.username.Trim(),
                            password = user.password.Trim(),
                            email = user.email.Trim(),
                            address = user.address.Trim(),
                            phone = user.phone.Trim(),
                            user_type = user.user_type.Trim(),
                            status = user.status
                        };
                        db.LoginUsers.Add(newuser);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewData["message"] = "User Name already exisits";
                        return View();
                    }
                    return RedirectToAction("ManageCustomer", "Admin");
                }
            }
            return View(user);

        }

        public ActionResult AddServiceProvider()
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
        public ActionResult AddServiceProvider(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                user.user_type = "ServiceProvider";
                using (ShebaDbEntities db = new ShebaDbEntities())
                {
                    var em = User.Identity.Name;
                    em = em.Trim();

                    var u = (from data in db.LoginUsers
                             where data.email.Trim() == em
                             select data).FirstOrDefault();
                    ViewData["username"] = u.username;
                    var entity = (from d in db.LoginUsers
                                  where d.email.Trim() == user.email.Trim()
                                  select d).FirstOrDefault();

                    if (entity == null)
                    {
                        var newuser = new LoginUser()
                        {
                            fullname = user.fullname.Trim(),
                            username = user.username.Trim(),
                            password = user.password.Trim(),
                            email = user.email.Trim(),
                            address = user.address.Trim(),
                            phone = user.phone.Trim(),
                            user_type = user.user_type.Trim(),
                            status = user.status
                        };
                        db.LoginUsers.Add(newuser);
                        db.SaveChanges();

                        var newsp = new service_provider_status()
                        {
                            service_provider_id = newuser.id,
                            status = "available"
                        };

                        db.service_provider_status.Add(newsp);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewData["message"] = "User Name already exisits";
                        return View();
                    }
                    return RedirectToAction("ManageServiceProvider", "Admin");
                }
            }
            return View(user);
        }

        // Add part ends

        // Delete Part begins

        public ActionResult DeleteManager(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
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
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
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

                var bc = (from data in db.Booking_confirms
                          where data.booking_id == bt.id
                          select data).FirstOrDefault();
                if (bc != null)
                {
                    db.Booking_confirms.Remove(bc);
                    db.SaveChanges();
                    var spst = (from data in db.service_provider_status
                                where bc.service_provider_id == data.id
                                select data).FirstOrDefault();

                    spst.status = "available";
                    db.SaveChanges();
                }

            }

            foreach(var x in book)
            {
                db.Bookings.Remove(x);
                db.SaveChanges();
            }

            var comp = (from data in db.Complaints
                        where data.customer_id == user.id
                        select data).ToList();
            foreach(var c in comp)
            {
                db.Complaints.Remove(c);
                db.SaveChanges();
            }

            db.LoginUsers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("ManageCustomer", "Admin");
        }

        public ActionResult DeleteServiceProvider(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
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
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
        }
        [HttpPost]
        public ActionResult EditManager(LoginUser user)
        {
            if (user.username != null && user.username!="")
                user.username = user.username.Trim();
            if (user.phone != null && user.phone!="")
                user.phone = user.phone.Trim();
            if (user.address != null && user.address!="")
                user.address = user.address.Trim();
            if (user.fullname != null && user.fullname!="")
                user.fullname = user.fullname.Trim();
            if (user.password != null && user.password!="")
                user.password = user.password.Trim();


            if (user.username == null || user.fullname == null || user.password == null || user.phone == null || user.address == null || user.username == "" || user.fullname == "" || user.password == "" || user.address == "" || user.phone == "")
            {
                return View(user);
            }
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();
                return View(user);
            }
        }

        public ActionResult EditCustomer(int id)
        {

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
        }
        [HttpPost]
        public ActionResult EditCustomer(LoginUser user)
        {
            if (user.username != null && user.username != "")
                user.username = user.username.Trim();
            if (user.phone != null && user.phone != "")
                user.phone = user.phone.Trim();
            if (user.address != null && user.address != "")
                user.address = user.address.Trim();
            if (user.fullname != null && user.fullname != "")
                user.fullname = user.fullname.Trim();
            if (user.password != null && user.password != "")
                user.password = user.password.Trim();


            if (user.username == null || user.fullname == null || user.password == null || user.phone == null || user.address == null || user.username == "" || user.fullname == "" || user.password == "" || user.address == "" || user.phone == "")
            {
                return View(user);
            }
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();

                var em = User.Identity.Name;
                em = em.Trim();

                var username = (from data in db.LoginUsers
                            where data.email.Trim() == em
                            select data).FirstOrDefault();
                ViewData["username"] = username.username;
                return View(user);
            }

        }

        public ActionResult EditServiceProvider(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.LoginUsers
                        where data.id == id
                        select data).FirstOrDefault();

            return View(u);
        }
        [HttpPost]
        public ActionResult EditServiceProvider(LoginUser user)
        {
            if (user.username != null && user.username != "")
                user.username = user.username.Trim();
            if (user.phone != null && user.phone != "")
                user.phone = user.phone.Trim();
            if (user.address != null && user.address != "")
                user.address = user.address.Trim();
            if (user.fullname != null && user.fullname != "")
                user.fullname = user.fullname.Trim();
            if (user.password != null && user.password != "")
                user.password = user.password.Trim();

            if (user.username == null || user.fullname == null || user.password == null || user.phone == null || user.address == null || user.username == "" || user.fullname == "" || user.password == "" || user.address == "" || user.phone == "")
            {
                return View(user);
            }
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();



                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();
                entity.status = user.status.Trim();
                entity.password = user.password.Trim();

                db.SaveChanges();

                var em = User.Identity.Name;
                em = em.Trim();

                var username = (from data in db.LoginUsers
                                where data.email.Trim() == em
                                select data).FirstOrDefault();
                ViewData["username"] = username.username;
                return View(user);
            }
        }

        // Edit Part Ends

        //..........................................................................// Service Part starts

        public ActionResult ManageService()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var serv = (from data in db.Services
                        where data.id > 0
                        select data).ToList();
            return View(serv);
        }

        public ActionResult EditService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var s = (from data in db.Services
                        where data.id == id
                        select data).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult EditService(Service s)
        {
            if (ModelState.IsValid)
            {
                using (ShebaDbEntities db = new ShebaDbEntities())
                {
                    var serv = (from data in db.Services
                                where data.id == s.id
                                select data).FirstOrDefault();

                    serv.name = s.name.Trim();
                    serv.category = s.category.Trim();
                    serv.description = s.description.Trim();
                    serv.cost = s.cost;
                    db.SaveChanges();
                    var em = User.Identity.Name;
                    em = em.Trim();

                    var username = (from data in db.LoginUsers
                                    where data.email.Trim() == em
                                    select data).FirstOrDefault();
                    ViewData["username"] = username.username;
                }
            }
            return View(s);
        }

        public ActionResult AddService()
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
        public ActionResult AddService(Service s)
        {
            if (ModelState.IsValid)
            {
                using (ShebaDbEntities db = new ShebaDbEntities())
                {
                    var entity = (from d in db.Services
                                  where d.name.Trim() == s.name.Trim()
                                  select d).FirstOrDefault();

                    if (entity == null)
                    {
                        var newserv = new Service()
                        {
                            name = s.name.Trim(),
                            category = s.category.Trim(),
                            description = s.description.Trim(),
                            cost = s.cost
                        };
                        db.Services.Add(newserv);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewData["message"] = "Service already exisits";
                        return View();
                    }
                }
            }
            return View(s);
        }

        public ActionResult DeleteService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
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
            var bd = (from data in db.Booking_details
                      where data.service_id == s.id
                      select data).ToList();

            foreach(var p in bd)
            {
                db.Booking_details.Remove(p);
                db.SaveChanges();
            }
            db.Services.Remove(serv);
            db.SaveChanges();
            return RedirectToAction("ManageService", "Admin");
        }

        //.....................................................................// Service Part ends

        //......................................................................// Complain Part starts
        public ActionResult ManageComplain()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var comp = (from data in db.Complaints
                        where data.status.Trim()=="unread"
                        select data).ToList();
            return View(comp);
        }

        public ActionResult EditComplain(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var comp = (from data in db.Complaints
                        where data.id == id
                        select data).FirstOrDefault();
            return View(comp);
        }
        [HttpPost]
        public ActionResult EditComplain(Complaint c)
        {
            if (c.description != null)
                c.description = c.description.Trim();
            if(c.description==null || c.description=="")
            {
                return View();
            }
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
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var booking = (from data in db.Bookings
                        where data.status.Trim()=="pending"
                        select data).ToList();
            return View(booking);
        }

        public ActionResult ConfirmBookedService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var sp = (from data in db.service_provider_status
                           where data.status.Trim() == "available"
                           select data).ToList();
            Session["confirm_booking"] = id;
            return View(sp);
        }

        public ActionResult DeleteBookedService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
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

            return RedirectToAction("ManageBookedService", "Admin");
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
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var book = (from data in db.Bookings
                        where data.id == id
                        select data).FirstOrDefault();

            return View(book);
        }
        [HttpPost]
        public ActionResult EditBookedService(Booking b)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var book = (from data in db.Bookings
                        where data.id == b.id
                        select data).FirstOrDefault();

            db.Entry(book).CurrentValues.SetValues(b);
            db.SaveChanges();
            return View(book);
        }

        public ActionResult AssignServiceProvider(int id)
        {

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

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

            var sp = (from data in db.service_provider_status
                      where data.service_provider_id == id
                      select data).First();
            sp.status = "busy";
            db.SaveChanges();

            return RedirectToAction("ManageBookedService", "Admin");
        }

        public ActionResult PaymentStatus()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var payment = (from data in db.Bookings
                           where data.id > 0
                           select data).ToList();

            return View(payment);
        }
        
        public ActionResult PaymentUpdate(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

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
            booking.payment_status = payment_status.Trim();

            db.Entry(booking).CurrentValues.SetValues(booking);
            db.SaveChanges();

            return RedirectToAction("PaymentStatus", "Admin");
        }

        public ActionResult ViewMessage()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var message = (from data in db.Contact_Messages
                           where data.id > 0
                           select data).ToList();
            return View(message);
        }

        public ActionResult DeleteMessage(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var message = (from data in db.Contact_Messages
                           where data.id == id
                           select data).FirstOrDefault();
            db.Contact_Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("ViewMessage", "Admin");
        }

        public ActionResult ViewDetails(int id)
        {
            var db = new ShebaDbEntities();

            var det = (from data in db.Booking_details
                       where data.booking_id == id
                       select data).ToList();

            var slist = new List<Service>();

            foreach(var p in det)
            {
                var x = (from data in db.Services
                         where data.id == p.service_id
                         select data).FirstOrDefault();
                slist.Add(x);
            }

            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(slist);
        }
    }
}
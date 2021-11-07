using Ghor_Sheba.Auth;
using Ghor_Sheba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Ghor_Sheba.Controllers
{
    [ServiceProviderAccess]
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider
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
            
            ViewData["username"] = u.username;
            return View(u);
        }

        public ActionResult ViewRequest()
        {
            var db = new ShebaDbEntities();

            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;
            var bid = (from data in db.Booking_confirms
                       where data.service_provider_id == user.id
                       select data).ToList();
            var booklist = new List<LoginUser>();

            foreach(var p in bid)
            {
                var book = (from data in db.Bookings
                            where data.id == p.booking_id
                            select data).FirstOrDefault();
                var cus = (from data in db.LoginUsers
                           where data.id == book.customer_id
                           select data).FirstOrDefault();
                booklist.Add(cus);
            }
            return View(booklist);
       
        }

        public ActionResult ManageService()
        {
            var db = new ShebaDbEntities();

            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var bid = (from data in db.Booking_confirms
                       where data.service_provider_id == user.id
                       select data).ToList();

            if(bid!=null)
            {
                var blist = new List<Booking>();
                foreach (var p in bid)
                {
                    var booking = (from data in db.Bookings
                                   where data.id == p.booking_id
                                   select data).FirstOrDefault();
                    blist.Add(booking);
                }
                return View(blist);
            }

            return RedirectToAction("Profile", "ServiceProvider");

        }

        public ActionResult EditService(int id)
        {
            var db = new ShebaDbEntities();

            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var bk = (from data in db.Bookings
                      where data.id == id
                      select data).FirstOrDefault();
            return View(bk);
        }
        [HttpPost]
        public ActionResult EditService(Booking b)
        {
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from d in db.Bookings
                              where d.id == b.id
                              select d).FirstOrDefault();



                entity.status = b.status.Trim();
                entity.payment_status = b.payment_status.Trim();

                db.SaveChanges();

                var em = User.Identity.Name;
                var user = (from data in db.LoginUsers
                            where data.email == em
                            select data).FirstOrDefault();
                ViewData["username"] = user.username;
            }
            return RedirectToAction("ManageService", "ServiceProvider");
        }

        public ActionResult ManageAvailability()
        {
            var db = new ShebaDbEntities();

            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.service_provider_status
                     where data.service_provider_id == user.id
                     select data).FirstOrDefault();

            return View(u);
        }

        [HttpPost]
        public ActionResult ManageAvailability(service_provider_status s)
        {
            var em = User.Identity.Name;

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var user = (from data in db.LoginUsers
                            where data.email == em
                            select data).FirstOrDefault();
                var entity = (from data in db.service_provider_status
                              where data.service_provider_id == user.id
                              select data).FirstOrDefault();


                entity.status = s.status.Trim();

                db.SaveChanges();

                ViewData["username"] = user.username;
            }

            return RedirectToAction("Profile", "ServiceProvider");
        }

        public ActionResult ViewHistory()
        {
            var db = new ShebaDbEntities();

            var em = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var u = (from data in db.Booking_confirms
                     where data.service_provider_id == user.id
                     select data).ToList();

            var blist = new List<Booking>();
            foreach(var bc in u)
            {
                var bk = (from data in db.Bookings
                          where data.id == bc.booking_id
                          select data).FirstOrDefault();
                blist.Add(bk);
            }
            return View(blist);
        }
    }
}
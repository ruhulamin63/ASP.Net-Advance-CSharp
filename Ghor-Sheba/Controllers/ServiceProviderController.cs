using Ghor_Sheba.Auth;
using Ghor_Sheba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ghor_Sheba.Controllers
{
    [ServiceProviderAccess]
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider
        public ActionResult Index()
        {
            var data = User.Identity.Name;
            var user = new JavaScriptSerializer().Deserialize<LoginUser>(data.ToString());
            ViewData["username"] = user.username;
            return View();
        }

        public ActionResult ViewRequest()
        {
            var db = new ShebaDbEntities();

            var d = User.Identity.Name;
            var user = new JavaScriptSerializer().Deserialize<LoginUser>(d.ToString());

            var bid = (from data in db.Booking_confirms
                       where data.service_provider_id == user.id
                       select data).ToList();

            return View(bid);
       
        }

        public ActionResult ManageService()
        {
            var db = new ShebaDbEntities();

            var d = User.Identity.Name;
            var user = new JavaScriptSerializer().Deserialize<LoginUser>(d.ToString());

            var bid = (from data in db.Booking_confirms
                       where data.service_provider_id == user.id
                       select data).FirstOrDefault();

            if(bid!=null)
            {
                var booking = (from data in db.Bookings
                               where data.id == bid.booking_id
                               select data).FirstOrDefault();
                return View(booking);
            }

            return RedirectToAction("Index", "ServiceProvider");

        }
    }
}
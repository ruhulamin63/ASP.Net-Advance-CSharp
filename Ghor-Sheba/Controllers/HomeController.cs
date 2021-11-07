using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghor_Sheba.Models;

namespace Ghor_Sheba.Controllers
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

        [HttpPost]
        public ActionResult Message(string name, string email, string subject, string message)
        {
            var db = new ShebaDbEntities();

            name = name.Trim();
            email = email.Trim();
            subject = subject.Trim();
            message = message.Trim();

            var m = new Contact_Messages()
            {
                name = name,
                email = email,
                subject = subject,
                message = message
            };
            db.Contact_Messages.Add(m);
            db.SaveChanges();

            return RedirectToAction("Contact", "Home");
        }
 

    }
}
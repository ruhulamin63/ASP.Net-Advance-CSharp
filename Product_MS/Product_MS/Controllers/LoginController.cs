using Product_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Product_MS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var db = new Database();
            var user = db.Users.Authenticate(Username, Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, true);

                return RedirectToAction("List","Product");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }
    }
}
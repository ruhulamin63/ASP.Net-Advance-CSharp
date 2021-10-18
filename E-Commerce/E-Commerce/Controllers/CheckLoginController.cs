using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce.Controllers
{
    public class CheckLoginController : Controller
    {
        // GET: CheckLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var db = new ProductEntities();

            var user = (from u in db.users
                       where u.Username.Equals(Username) && u.Password.Equals(Password)
                       select u);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.FirstOrDefault().Username, true);
                FormsAuthentication.SetAuthCookie(user.FirstOrDefault().Password, true);
                
                Session["AccessLevel"] = user.FirstOrDefault().AccessLevel;
                Session["Id"] = user.FirstOrDefault().Id;

                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "CheckLogin");
        }
    }
}
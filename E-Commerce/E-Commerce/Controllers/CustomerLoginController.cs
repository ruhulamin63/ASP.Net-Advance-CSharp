using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CheckLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Phone, string Password)
        {
            var db = new ProductEntities();

            var user = (from u in db.customers
                       where u.Phone.Equals(Phone) && u.Password.Equals(Password)
                       select u);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.FirstOrDefault().Name, true);
                //FormsAuthentication.SetAuthCookie(user.FirstOrDefault().Password, true);
                
                Session["phone"] = user.FirstOrDefault();
                //Session["Id"] = user.FirstOrDefault();

                return RedirectToAction("Index", "Customer");
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
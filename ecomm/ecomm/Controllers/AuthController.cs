using ecomm.Models.EF;
using ecomm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ecomm.Controllers
{
    public class AuthController : Controller
    {
        static e_commerce_siteEntities db;

        static AuthController()
        {
            db = new e_commerce_siteEntities();
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id, string password)
        {
            var user = AuthRepository.Authenticate(id,password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.password, true);

                return RedirectToAction("Cart", "Product");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Auth");
        }
    }
}
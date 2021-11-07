using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Ghor_Sheba.Models;
using Newtonsoft.Json;

namespace Ghor_Sheba.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (User.Identity.Name == "") {
                return View();
            }

            string em = User.Identity.Name;
            em = em.Trim();
            var db = new ShebaDbEntities();
            var u = (from d in db.LoginUsers
                     where d.email.Trim() == em
                     select d).FirstOrDefault();

            if(u!=null)
            {
                u.username = u.username.Trim();
                u.fullname = u.fullname.Trim();
                u.password = u.password.Trim();
                u.email = u.email.Trim();
                u.address = u.address.Trim();
                u.phone = u.phone.Trim();
                u.user_type = u.user_type.Trim();
                u.status = u.status.Trim();
            }

            if (u.user_type == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (u.user_type == "ServiceProvider")
            {
                return RedirectToAction("Profile", "ServiceProvider");
            }
            else if(u.user_type == "Customer")
            {
                return RedirectToAction("Profile", "Customer");
            }
            else if(u.user_type == "Manager")
            {
                return RedirectToAction("Index", "Manager");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email != null && email != "")
                email = email.Trim();
            if (password != null && password != "")
                password = password.Trim();

            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == email && data.password.Trim() == password
                        select data).FirstOrDefault();
            if(user!=null)
            {
                user.username = user.username.Trim();
                user.fullname = user.fullname.Trim();
                user.password = user.password.Trim();
                user.email = user.email.Trim();
                user.address = user.address.Trim();
                user.phone = user.phone.Trim();
                user.user_type = user.user_type.Trim();
                user.status = user.status.Trim();
            }

            if(user!=null && user.status=="unblocked")
            {
                if(user.user_type=="Admin")
                {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Index", "Admin");
                }
                else if(user.user_type=="ServiceProvider")
                {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Profile", "ServiceProvider");
                }
                else if(user.user_type=="Customer")
                {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Profile", "Customer");
                }
                else if (user.user_type == "Manager")
                {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Index", "Manager");
                }

            }
            else if(user!=null && user.status=="blocked")
            {
                ViewData["message"] = "Please send a message through contact form. We will get back to you";
                
            }
            else
            {
                ViewData["message"] = "Email or Password is incorrect";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Signup()
        {
            return View();
        }
    }
}
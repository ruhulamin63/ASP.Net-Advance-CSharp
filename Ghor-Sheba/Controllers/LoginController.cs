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

            var db = new ShebaDbEntities();
            var data = User.Identity.Name;
            var user = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            if (user.user_type == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (user.user_type == "ServiceProvider")
            {
                return RedirectToAction("Index", "ServiceProvider");
            }
            else if(user.user_type == "Customer")
            {
                return RedirectToAction("Index", "Customer");
            }
            else if(user.user_type == "Manager")
            {
                return RedirectToAction("Index", "Manager");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var db = new ShebaDbEntities();
            var user = (from data in db.LoginUsers
                        where data.email == email && data.password == password
                        select data).FirstOrDefault();


            if(user!=null)
            {
                if(user.user_type=="Admin")
                {
                    string json = JsonConvert.SerializeObject(user);
                    FormsAuthentication.SetAuthCookie(json, true);
                    return RedirectToAction("Index", "Admin");
                }
                else if(user.user_type=="ServiceProvider")
                {
                    string json = JsonConvert.SerializeObject(user);
                    FormsAuthentication.SetAuthCookie(json, true);
                    return RedirectToAction("Index", "ServiceProvider");
                }
                else if(user.user_type=="Customer")
                {
                    string json = JsonConvert.SerializeObject(user);
                    FormsAuthentication.SetAuthCookie(json, true);
                    return RedirectToAction("Index", "Customer");
                }
                else if (user.user_type == "Manager")
                {
                    string json = JsonConvert.SerializeObject(user);
                    FormsAuthentication.SetAuthCookie(json, true);
                    return RedirectToAction("Index", "Manager");
                }

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
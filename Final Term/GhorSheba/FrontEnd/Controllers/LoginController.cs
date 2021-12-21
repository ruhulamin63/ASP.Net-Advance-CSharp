using BEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            var tu = Session["token_user"];
            if(tu!=null)
            {
                string u = tu.ToString();
                if(u=="Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if(u=="Manager")
                {
                    return RedirectToAction("Index", "Manager");
                }
                else if(u=="ServiceProvider")
                {
                    return RedirectToAction("EditServiceProvider", "ServiceProvider");
                }
                else if(u=="Customer")
                {
                    return RedirectToAction("Profile", "Customer");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var u = new UserModel()
            {
                email = email,
                password = password
            };

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/login", u).Result;
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var success = JsonConvert.DeserializeObject<TokenModel>(SuccessResponse);
                if (success != null)
                {
                    var token = success.access_token;
                    Session["token"] = token;
                    Session["u_id"] = success.user_id;
                    HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("api/Auth/GetUserType/" + success.user_id).Result;
                    if (response1.IsSuccessStatusCode)
                    {
                        var SuccessResponse1 = response1.Content.ReadAsStringAsync().Result;
                        var success1 = JsonConvert.DeserializeObject<UserModel>(SuccessResponse1);
                        if (success1 != null)
                        {
                            FormsAuthentication.SetAuthCookie(success1.usertype, true);
                            if (success1.usertype == "Admin")
                            {
                                Session["token_user"] = "Admin";
                                return RedirectToAction("Index", "Admin");
                            }
                            else if (success1.usertype == "Manager")
                            {
                                Session["token_user"] = "Manager";
                                return RedirectToAction("Index", "Manager");
                            }
                            else if (success1.usertype == "ServiceProvider")
                            {
                                Session["token_user"] = "ServiceProvider";
                                return RedirectToAction("EditServiceProvider", "ServiceProvider");
                            }
                            else if (success1.usertype == "Customer")
                            {
                                Session["token_user"] = "Customer";
                                return RedirectToAction("Profile", "Customer");
                            }
                        }
                    }
                }
             }
            return View();
        }

        public ActionResult Logout()
        {
            int id = Int32.Parse(Session["u_id"].ToString());

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Login/DeleteToken/"+id.ToString()).Result;
            
            if (response.IsSuccessStatusCode)
            {
                var SuccessResponse = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<UserModel>(SuccessResponse);
            }
            Session.Remove("u_id");
            Session.Remove("token");
            Session.Remove("token_user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}
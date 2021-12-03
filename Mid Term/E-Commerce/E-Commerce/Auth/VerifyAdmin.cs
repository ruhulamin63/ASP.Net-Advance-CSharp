using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;
namespace E_Commerce.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class VerifyAdmin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;
                var db = new ProductEntities();

                var type = (from u in db.users
                                 where u.Username.Equals(username)
                                 select u).FirstOrDefault();

                if (type.AccessLevel == "Admin")
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
using Product_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_MS.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class AdminAccess:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                var user = httpContext.User.Identity.Name;

                /* httpContext.User.Identity.IsAuthenticated;*/

                var db = new Database();

                var type = db.Users.GetUserType(user);

                if(type == "Admin")
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
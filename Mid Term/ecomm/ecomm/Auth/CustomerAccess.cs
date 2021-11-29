using ecomm.Models.EF;
using ecomm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecomm.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class CustomerAccess: AuthorizeAttribute
    {
        static e_commerce_siteEntities db;

        static CustomerAccess()
        {
            db = new e_commerce_siteEntities();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                var user = httpContext.User.Identity.Name;

                /* httpContext.User.Identity.IsAuthenticated;*/

                var type = AuthRepository.GetUserType(user);

                if (type.AccessLevel == "needhelp")
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
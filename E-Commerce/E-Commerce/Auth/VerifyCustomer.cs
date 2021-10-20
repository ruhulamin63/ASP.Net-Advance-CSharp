using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class VerifyCustomer : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                var user = httpContext.User.Identity.Name;

                /* httpContext.User.Identity.IsAuthenticated;*/

                var db = new ProductEntities();

                var type = (from u in db.customers where u.Phone.Equals(user)
                            select u).FirstOrDefault();

               /* if (type )
                {
                    return true;
                }*/
            }
            return false;
        }
    }
}
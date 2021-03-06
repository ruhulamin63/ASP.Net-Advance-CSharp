using Ghor_Sheba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ghor_Sheba.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ServiceProviderAccess:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                var user = httpContext.User.Identity.Name;
                //var u = new JavaScriptSerializer().Deserialize<LoginUser>(user.ToString());
                var db = new ShebaDbEntities();
                var u = (from data in db.LoginUsers
                         where data.email == user
                         select data).FirstOrDefault();

                var d = (from data in db.LoginUsers
                         where data.id == u.id
                         select data).FirstOrDefault();
                if (d.user_type == "ServiceProvider")
                {
                    return true;
                }

            }
            return false;
        }
    }
}
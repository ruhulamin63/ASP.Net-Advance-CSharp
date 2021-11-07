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
    public class AdminAccess:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);

            if(flag)
            {
                var user = httpContext.User.Identity.Name;
                //var u = new JavaScriptSerializer().Deserialize<LoginUser>(user.ToString());
                var db = new ShebaDbEntities();

                var d = (from data in db.LoginUsers
                         where data.email == user
                         select data).FirstOrDefault();
                if(d.user_type=="Admin")
                {
                    return true;
                }
        
            }
            return false;
        }
    }
}
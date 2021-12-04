using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApp.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Auth(UserModel user)
        {
            var data = AuthService.Auth(user);

            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
    }
}

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
        public TokenModel Auth(UserModel user) {
            var data = AuthService.Auth(user);
            if (data != null) {
                return data;
            }
            return data;
        }

        [Route("api/Auth/GetUserType/{id:int}")]
        [HttpGet]
        public UserModel GetUserType(int id)
        {
            return AuthService.GetUserType(id);
        }

        [Route("api/Auth/DeleteToken")]
        [HttpPost]
        public void DeleteToken(int id)
        {
            AuthService.DeleteToken(id);
        }
    }
}

using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GhorSheba.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Login/DeleteToken/{id:int}")]
        [HttpGet]
        public void DeleteToken(int id)
        {
            AuthService.DeleteToken(id);
        }
    }
}

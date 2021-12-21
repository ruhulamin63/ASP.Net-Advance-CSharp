using BLL.ManagerServices;
using GhorSheba.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers.ManagerController
{
    [AuthManager]
    public class CustomerController : ApiController
    {
        [Route("api/customer/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CustomerService.GetAll());
        }
    }
}

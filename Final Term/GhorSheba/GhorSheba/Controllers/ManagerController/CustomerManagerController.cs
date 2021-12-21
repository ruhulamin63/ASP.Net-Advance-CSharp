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
    public class CustomerManagerController : ApiController
    {
        [Route("api/customer/all")]
        [HttpGet]
        public HttpResponseMessage CustomerGetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CustomerService.CustomerGetAll());
        }

        [Route("api/customer/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage CustomerDelete(int id)
        {
            CustomerService.DeleteC(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

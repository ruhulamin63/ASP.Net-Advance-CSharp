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
    public class ReviewController : ApiController
    {
        [Route("api/review/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ReviewService.GetAll());
        }
        [Route("api/review/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ReviewService.Get(id));
        }
    }
}

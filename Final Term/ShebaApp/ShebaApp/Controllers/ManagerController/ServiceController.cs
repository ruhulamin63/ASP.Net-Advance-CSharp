using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers
{
    public class ServiceController : ApiController
    {
        [Route("api/service/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceToService.GetAll());
        }
        [Route("api/service/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceToService.Get(id));
        }
        [Route("api/service/create")]
        [HttpPost]
        public HttpResponseMessage Add(ServiceModel user)
        {
            ServiceToService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/service/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(ServiceModel user)
        {
            ServiceToService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/service/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            ServiceToService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }

        //==================================================================================================
    }
}

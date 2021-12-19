using BEL;
using BLL.ManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers.ManagerController
{
    public class ServiceProviderController : ApiController
    {
        [Route("api/service/provider/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServices.GetAll());
        }
        [Route("api/service/provider/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServices.Get(id));
        }
        [Route("api/service/provider/create")]
        [HttpPost]
        public HttpResponseMessage Add(ServiceProviderModel user)
        {
            ServiceProviderServices.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/service/provider/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(ServiceProviderModel user)
        {
            ServiceProviderServices.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/service/provider/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            ServiceProviderServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }


        [Route("api/service/cbs/{id}")]
        [HttpGet]
        public HttpResponseMessage ConfirmBookedService(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServices.ConfirmBookedService(id));
        } 
        
        [Route("api/assign/service/{id}")]
        [HttpGet]
        public HttpResponseMessage AssignServices(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServices.AssignServices(id));
        }

    }
}

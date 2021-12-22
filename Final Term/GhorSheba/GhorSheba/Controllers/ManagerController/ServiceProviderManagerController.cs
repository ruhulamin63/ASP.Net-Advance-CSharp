using BEL;
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
    public class ServiceProviderManagerController : ApiController
    {
        [Route("api/service/provider/all")]
        [HttpGet]
        public HttpResponseMessage GetSP()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServicesManager.GetAll());
        }
        [Route("api/service/provider/{id}")]
        [HttpGet]
        public HttpResponseMessage GetSP(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServicesManager.Get(id));
        }
        [Route("api/service/provider/create")]
        [HttpPost]
        public HttpResponseMessage AddSP(ServiceProviderModel user)
        {
            ServiceProviderServicesManager.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/service/provider/edit")]
        [HttpPost]
        public HttpResponseMessage EditSP(ServiceProviderModel user)
        {
            ServiceProviderServicesManager.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/service/provider/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSP(int id)
        {
            ServiceProviderServicesManager.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }


        [Route("api/service/cbs/{id}")]
        [HttpGet]
        public HttpResponseMessage ConfirmBookedService(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServicesManager.ConfirmBookedService(id));
        }

        /* [Route("api/service/cbs")]
         [HttpGet]
         public void ConfirmBooking(BookingServiceModel s)
         {
             ServiceProviderServices.ConfirmBooking(s);
         }*/

        [Route("api/assign/service")]
        [HttpPost]
        public void AssignServices(BookingServiceModel s)
        {
            //return Request.CreateResponse(HttpStatusCode.OK, ServiceProviderServicesManager.AssignServices(id));

            ServiceProviderServicesManager.AssignServices(s);
        }

    }
}

using BEL;
using BLL;
using GhorSheba.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers
{
    [AuthManager]
    public class BookingServiceController : ApiController
    {
        [Route("api/booking/service/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingServiceToService.GetAll());
        }
        [Route("api/booking/service/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingServiceToService.Get(id));
        }

        [Route("api/booking/service/create")]
        [HttpPost]
        public HttpResponseMessage Add(BookingServiceModel user)
        {
            BookingServiceToService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }

        [Route("api/booking/service/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookingServiceModel user)
        {
            BookingServiceToService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }

        [Route("api/booking/service/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            BookingServiceToService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

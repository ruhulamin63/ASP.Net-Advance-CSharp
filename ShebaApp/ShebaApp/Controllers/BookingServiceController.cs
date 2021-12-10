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
    public class BookingServiceController : ApiController
    {
        [Route("api/booking/service/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingServiceTable.GetAll());
        }
        [Route("api/booking/service/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingServiceTable.Get(id));
        }

        [Route("api/booking/service/create")]
        [HttpPost]
        public HttpResponseMessage Add(BookingServiceModel user)
        {
            BookingServiceTable.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }

        [Route("api/booking/service/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookingServiceModel user)
        {
            BookingServiceTable.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }

        [Route("api/booking/service/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BookingServiceTable.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

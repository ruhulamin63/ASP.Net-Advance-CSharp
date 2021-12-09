using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers
{
    public class BookingController : ApiController
    {
        [Route("api/booking/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingService.GetAll());
        }
        [Route("api/booking/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingService.Get(id));
        }
        [Route("api/booking/create")]
        [HttpPost]
        public HttpResponseMessage Add(BookingModel user)
        {
            BookingService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/booking/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookingModel user)
        {
            BookingService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/booking/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BookingService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

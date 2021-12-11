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
    public class BookingDetailsController : ApiController
    {
        [Route("api/booking/details/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingDetailsService.GetAll());
        }
        [Route("api/booking/details/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingDetailsService.Get(id));
        }
        [Route("api/booking/details/create")]
        [HttpPost]
        public HttpResponseMessage Add(BookingDetailsModel user)
        {
            BookingDetailsService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/booking/details/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookingDetailsModel user)
        {
            BookingDetailsService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/booking/details/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BookingDetailsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }

        //==================================================================================================
    }
}

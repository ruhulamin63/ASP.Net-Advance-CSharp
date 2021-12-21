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
    public class BookingDetailsController : ApiController
    {
        [Route("api/booking/confirm/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingDetailsService.GetAll());
        }
        [Route("api/booking/confirm/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, BookingDetailsService.Get(id));
        }
        [Route("api/booking/confirm/create")]
        [HttpPost]
        public HttpResponseMessage Add(BookingDetailModel user)
        {
            BookingDetailsService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/booking/confirm/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookingDetailModel user)
        {
            BookingDetailsService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/booking/confirm/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BookingDetailsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }

        //==================================================================================================
    }
}

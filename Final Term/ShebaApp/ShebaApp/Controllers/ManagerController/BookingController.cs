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
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            BookingService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }

        [Route("api/get/odate/date")]
        [HttpGet]
        public HttpResponseMessage GetByOrderDate([FromUri] DateTime order_date)
        {
            var data = BookingService.GetByOrderDate(order_date);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
        }

        [Route("api/get/cid/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByCustomerId(int id)
        {
            var data = BookingService.GetByCustomerId(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
        }

        [Route("api/get/odate/cid/{date}")]
        [HttpGet]
        public HttpResponseMessage GetByOrderDateCustomerId([FromUri] DateTime order_date, [FromUri] int c_id)
        {
            var data = BookingService.GetByOrderDateCustomerId(order_date, c_id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
        }
    }
}

using BEL.ManagerModel;
using BLL.ManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers.ManagerController
{
    public class CouponController : ApiController
    {
        [Route("api/coupon/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CouponService.GetAll());
        }
        [Route("api/coupon/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, CouponService.Get(id));
        }

        [Route("api/coupon/create")]
        [HttpPost]
        public HttpResponseMessage Add(CouponModel user)
        {
            CouponService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }

        [Route("api/coupon/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(CouponModel user)
        {
            CouponService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }

        [Route("api/coupon/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            CouponService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

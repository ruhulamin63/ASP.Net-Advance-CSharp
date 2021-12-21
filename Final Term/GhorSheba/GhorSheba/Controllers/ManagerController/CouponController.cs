using BEL;
using BEL.ManagerModel;
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
    public class CouponController : ApiController
    {
        [Route("api/coupon/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, CouponService.GetCoupons());
        }
        [Route("api/coupon/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, CouponService.GetCoupon(id));
        }

        [Route("api/coupon/create")]
        [HttpPost]
        public HttpResponseMessage Add(CouponModel user)
        {
            CouponService.AddCoupon(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }

        [Route("api/coupon/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(CouponModel user)
        {
            CouponService.EditCoupon(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }

        [Route("api/coupon/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            CouponService.DeleteCoupon(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

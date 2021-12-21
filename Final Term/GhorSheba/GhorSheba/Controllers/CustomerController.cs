using BEL;
using BLL;
using GhorSheba.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GhorSheba.Controllers
{
    [AuthCustomer]
    public class CustomerController : ApiController
    {
        [Route("api/Customer/CusUser/{id:int}")]
        [HttpGet]
        public CusProfileModel GetCusUser(int id)
        {
            return CustomerService.GetCusUser(id);
        }

        [Route("api/Customer/EditProfile")]
        [HttpPost]
        public void EditProfile(CusProfileModel u)
        {
            CustomerService.EditProfile(u);
        }

        [Route("api/Customer/GetID/{id:int}")]
        [HttpGet]
        public int GetID(int id)
        {
            return CustomerService.GetID(id);
        }

        [Route("api/Customer/GetBooking/{id:int}")]
        [HttpGet]
        public List<BookingModel> GetBooking(int id)
        {
            return CustomerService.GetBooking(id);
        }

        [Route("api/Customer/GetDetail/{id:int}")]
        [HttpGet]
        public List<CusBookingDetailModel> GetDetail(int id)
        {
            return CustomerService.GetDetail(id);
        }

        [Route("api/Customer/CancelBooking/{id:int}")]
        [HttpGet]
        public void CancelBooking(int id)
        {
            CustomerService.CancelBooking(id);
        }

        [Route("api/Customer/Checkout")]
        [HttpPost]
        public void Checkout(List<CusBookingModel> c)
        {
            CustomerService.Checkout(c);
        }

        [Route("api/Customer/AvailableCoupon/{id:int}")]
        [HttpGet]
        public List<CouponModel> AvailableCoupon(int id)
        {
            return CustomerService.AvailableCoupon(id);
        }

        [Route("api/Customer/GetBookingById/{id:int}")]
        [HttpGet]
        public BookingModel GetBookingById(int id)
        {
            return CustomerService.GetBookingById(id);
        }

        [Route("api/Customer/ApplyToken")]
        [HttpPost]
        public void ApplyToken(CustomerCouponModel c)
        {
            CustomerService.ApplyToken(c);
        }
    }
}

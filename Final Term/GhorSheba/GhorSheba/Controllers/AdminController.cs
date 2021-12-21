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
    [AuthAdmin]
    public class AdminController : ApiController
    {
        [Route("api/Admin/AllAdmin")]
        [HttpGet]

        public List<UserModel> GetAllAdmin()
        {
            return UserService.GetAll("Admin");
        }

        [Route("api/Admin/Profile/{id:int}")]
        [HttpGet]

        public UserModel Profile(int id)
        {
            return UserService.Profile(id);
        }

        [Route("api/Admin/Profile")]
        [HttpPost]

        public void Profile(UserModel u)
        {
            UserService.Profile(u);
        }

        [Route("api/Admin/AllManager")]
        [HttpGet]

        public List<UserModel> GetAllManager()
        {
            return UserService.GetAll("Manager");
        }

        [Route("api/Admin/AllCustomer")]
        [HttpGet]

        public List<UserModel> GetAllCustomer()
        {
            return UserService.GetAll("Customer");
        }

        [Route("api/Admin/AllServiceProvider")]
        [HttpGet]

        public List<UserModel> GetAllServiceProvider()
        {
            return UserService.GetAll("ServiceProvider");
        }

        [Route("api/Admin/CusUser/{id:int}")]
        [HttpGet]
        public EditCustomerModel GetCusUser(int id)
        {
            return UserService.GetCusUser(id);
        }

        //********************************Get Users done****************************//
        [Route("api/Admin/AddCustomer")]
        [HttpPost]
        public int AddCustomer(CusUser u)
        {
            return UserService.AddCustomer(u);
        }

        [Route("api/Admin/EditCustomer")]
        [HttpPost]
        public void EditCustomer(EditCustomerModel u)
        {
            UserService.EditCustomer(u);
        }
        [Route("api/Admin/DeleteCustomer/{id:int}")]
        [HttpDelete]
        public int DeleteCustomer(int id)
        {
            return UserService.DeleteCustomer(id);
        }

        //******************************************** Customer CRUD ends **************************************//

        //******************************************** Service Provider CRUD starts ****************************//

        [Route("api/Admin/AddServiceProvider")]
        [HttpPost]
        public int AddServiceProvider(ServUserModel u)
        {
            return UserService.AddServiceProvider(u);
        }

        [Route("api/Admin/ServUser/{id:int}")]
        [HttpGet]
        public EditServiceProviderModel GetServUser(int id)
        {
            return UserService.GetServUser(id);
        }

        [Route("api/Admin/EditServiceProvider")]
        [HttpPost]
        public void EditServiceProvider(EditServiceProviderModel u)
        {
            UserService.EditServiceProvider(u);
        }

        [Route("api/Admin/DeleteServiceProvider/{id:int}")]
        [HttpDelete]
        public int DeleteServiceProvider(int id)
        {
            return UserService.DeleteServiceProvider(id);
        }

        //***************************************** Service Provider CRUD ends *************************//

        //***************************************** Manager CRUD starts ********************************//

        [Route("api/Admin/AddManager")]
        [HttpPost]
        public int AddManager(UserModel u)
        {
            return UserService.AddManager(u);
        }


        [Route("api/Admin/GetManager/{id:int}")]
        [HttpGet]
        public EditUserModel GetManager(int id)
        {
            return UserService.GetManager(id);
        }
        [Route("api/Admin/EditManager")]
        [HttpPost]
        public void EditManager(EditUserModel u)
        {
            UserService.EditManager(u);
        }

        [Route("api/Admin/DeleteManager/{id:int}")]
        [HttpDelete]
        public int DeleteManager(int id)
        {
            return UserService.DeleteManager(id);
        }

        //***************************************** Manager CRUD starts ********************************//

        //**************************************** Services CRUD starts ********************************//

        [Route("api/Admin/GetServices/{id:int}")]
        [HttpGet]
        public List<ServiceModel> GetServices(int id)
        {
            return UserService.GetServices(id);
        }

        [Route("api/Admin/AddServices")]
        [HttpPost]
        public void AddServices(ServiceModel s)
        {
            UserService.AddServices(s);
        }

        [Route("api/Admin/GetService/{id:int}")]
        [HttpGet]
        public EditServiceModel GetService(int id)
        {
            return UserService.GetService(id);
        }

        [Route("api/Admin/GetServices")]
        [HttpGet]
        public List<ServiceModel> GetServices()
        {
            return UserService.GetServices();
        }

        [Route("api/Admin/EditServices")]
        [HttpPost]
        public void EditServices(EditServiceModel s)
        {
            UserService.EditServices(s);
        }

        [Route("api/Admin/DeleteServices/{id:int}")]
        [HttpDelete]
        public int DeleteServices(int id)
        {
            return UserService.DeleteServices(id);
        }

        //**************************************** Services CRUD ends ********************************//

        //**************************************** Booking part starts ********************************//

        [Route("api/Admin/GetBookings")]
        [HttpGet]
        public List<BookingModel> GetBookings()
        {
            return UserService.GetBookings();
        }

        [Route("api/Admin/GetBookingsLastMonth")]
        [HttpGet]
        public BookingModel GetBookingsLastMonth(int id)
        {
            return UserService.GetBookingsLastMonth(id);
        }

        [Route("api/Admin/GetBooking/{id:int}")]
        [HttpGet]
        public BookingModel GetBooking(int id)
        {
            return UserService.GetBooking(id);
        }

        [Route("api/Admin/EditBooking")]
        [HttpPost]
        public void EditBooking(BookingModel b)
        {
            UserService.EditBooking(b);
        }

        [Route("api/Admin/GetBookingDetails/{id:int}")]
        [HttpGet]
        public List<AdminBookingDetailModel> GetBookingDetails(int id)
        {
            return UserService.GetBookingDetails(id);
        }

        [Route("api/Admin/GetBookingDetails")]
        [HttpGet]
        public List<BookingDetailModel> GetBookingDetails()
        {
            return UserService.GetBookingDetails();
        }

        //**************************************** Booking part ends ********************************//

        //**************************************** Coupon part starts ********************************//

        [Route("api/Admin/GetCoupons")]
        [HttpGet]
        public List<CouponModel> GetCoupons()
        {
            return UserService.GetCoupons();
        }

        [Route("api/Admin/GetCoupon/{id:int}")]
        [HttpGet]
        public CouponModel GetCoupon(int id)
        {
            return UserService.GetCoupon(id);
        }

        [Route("api/Admin/AddCoupon")]
        [HttpPost]
        public void AddCoupon(CouponModel c)
        {
            UserService.AddCoupon(c);
        }

        [Route("api/Admin/EditCoupon")]
        [HttpPost]
        public void EditCoupon(CouponModel c)
        {
            UserService.EditCoupon(c);
        }

        [Route("api/Admin/DeleteCoupon/{id:int}")]
        [HttpDelete]
        public int DeleteCoupon(int id)
        {
            return UserService.DeleteCoupon(id);
        }

        //**************************************** Coupon part ends ********************************//

        //**************************************** Assign SP part ends ********************************//

        [Route("api/Admin/GetSP")]
        [HttpGet]
        public List<ServiceProviderModel> GetSP()
        {
            return UserService.GetSP();
        }

        [Route("api/Admin/ConfirmBooking")]
        [HttpPost]
        public void ConfirmBooking(BookingServiceModel s)
        {
            UserService.ConfirmBooking(s);
        }

        [Route("api/Admin/ViewSalaries")]
        [HttpGet]
        public List<UserSalariesModel> ViewSalaries()
        {
            return UserService.ViewSalaries();
        }

        [Route("api/Admin/PaySalary/{id:int}")]
        [HttpGet]
        public void PaySalary(int id)
        {
            UserService.PaySalary(id);
        }
    }
}

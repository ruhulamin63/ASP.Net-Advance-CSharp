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
    [AuthServiceProvider]
    public class ServiceProviderController : ApiController
    {
        [Route("api/ServiceProvider/Profile/{id:int}")]
        [HttpGet]
        public ServUserModel GetServUser(int id)
        {
            return ServiceProviderService.GetServUser(id);
        }

        [Route("api/ServiceProvider/Profile")]
        [HttpPost]
        public void EditServiceProvider(ServUserModel u)
        {
            ServiceProviderService.EditServiceProvider(u);
        }

        [Route("api/ServiceProvider/Bookedit/{id:int}")]
        [HttpGet]
        public Book_Bookingser GetBook_Bookingser(int id)
        {
            return ServiceProviderService.GetBook_Bookingser(id);
        }

        [Route("api/ServiceProvider/Bookedit")]
        [HttpPost]
        public void EditBooking(Book_Bookingser u)
        {
            ServiceProviderService.EditBooking(u);
        }


        [Route("api/ServiceProvider/CheckReview")]
        [HttpGet]

        public List<SerReviewModel> GetAllReview()
        {
            return ServiceProviderService.GetReview();
        }

        [Route("api/ServiceProvider/CheckBonus/{id:int}")]
        [HttpGet]

        public ServiceProviderBonusModel GetServiceProviderBonusModel(int id)
        {
            return ServiceProviderService.GetServiceProviderBonusModel(id);
        }

        [Route("api/ServiceProvider/ServiceDetail/{id:int}")]
        [HttpGet]

        public List<ServiceDetailModel> GetDetail(int id)
        {
            return ServiceProviderService.GetDetail(id);
        }

        [Route("api/ServiceProvider/WorkDetail/{id:int}")]
        [HttpGet]

        public List<AdminBookingDetailModel> WorkDetail(int id)
        {
            return ServiceProviderService.WorkDetail(id);
        }


        [Route("api/ServiceProvider/WorkStatus/{id:int}")]
        [HttpGet]
        public ServiceProviderModel GetWorkStatus(int id)
        {
            return ServiceProviderService.GetServiceProviderModel(id);
        }

        [Route("api/ServiceProvider/WorkStatus")]
        [HttpPost]
        public void Workstatus(ServiceProviderModel u)
        {
            ServiceProviderService.WorkStatus(u);
        }

        [Route("api/ServiceProvider/ViewBooking/{id:int}")]
        [HttpGet]
        public List<BookingModel> ViewBooking(int id)
        {
            return ServiceProviderService.ViewBooking(id);
        }


    }
}

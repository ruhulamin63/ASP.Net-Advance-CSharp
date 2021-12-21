using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GhorSheba.Controllers
{
    public class HomeController : ApiController
    {
        [Route("api/Home/GetServices/{id:int}")]
        [HttpGet]
        public List<ServiceModel> GetServices(int id)
        {
            return CustomerService.GetServices(id);
        }

        [Route("api/Home/GetService/{id:int}")]
        [HttpGet]
        public EditServiceModel GetService(int id)
        {
            return UserService.GetService(id);
        }

        [Route("api/Home/AddCustomer")]
        [HttpPost]
        public void AddCustomer(CusUser c)
        {
            CustomerService.AddCustomer(c);
        }
    }
}

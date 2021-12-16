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
    public class DiscountController : ApiController
    {
        [Route("api/discount/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DiscountService.GetAll());
        }

        [Route("api/discount/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, DiscountService.Get(id));
        }

        [Route("api/discount/create/{id}")]
        [HttpPost]
        public HttpResponseMessage Add(DiscountModel user,int id)
        {
            DiscountService.Add(user,id);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }

        [Route("api/discount/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(DiscountModel user)
        {
            DiscountService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }

        [Route("api/discount/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            DiscountService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}

using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShebaApp.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
           // return Request.CreateResponse(HttpStatusCode.OK, UserService.GetAll("manager"));
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetAll());
        }
        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
        }
        [Route("api/users/create")]
        [HttpPost]
        public HttpResponseMessage Add(UserModel user)
        {
            UserService.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/users/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/users/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}
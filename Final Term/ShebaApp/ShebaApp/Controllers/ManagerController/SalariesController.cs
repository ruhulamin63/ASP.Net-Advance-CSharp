﻿using BEL.ManagerModel;
using BLL.ManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShebaApp.Controllers.ManagerController
{
    public class SalariesController : ApiController
    {
        [Route("api/salary/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SalaryService.GetAll());
        }
        [Route("api/salary/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, SalaryService.Get(id));
        }
        [Route("api/salary/create/{id}")]
        [HttpPost]
        public HttpResponseMessage Add(SalaryModel user, int id)
        {
            SalaryService.Add(user,id);
            return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Created");
        }
        [Route("api/salary/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(SalaryModel user)
        {
            SalaryService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated Succesfully");
        }
        [Route("api/salary/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            SalaryService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Succesfully");
        }
    }
}
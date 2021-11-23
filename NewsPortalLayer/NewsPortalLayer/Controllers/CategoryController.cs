using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortalLayer.Controllers
{
    public class CategoryController : ApiController
    {
        [Route("api/get/category/all")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = NewsCategoryService.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/get/category")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = NewsCategoryService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/add/category")]
        [HttpPost]
        public IHttpActionResult Add(NewsCategoryModel n)
        {
            if (NewsCategoryService.Add(n))
            {
                return Ok();
            }
            return BadRequest();
        }
   
        [Route("api/edit/category")]
        [HttpPost]
        public IHttpActionResult Edit(NewsCategoryModel n)
        {
            if (NewsCategoryService.Edit(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("api/delete/category")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            if (NewsCategoryService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("api/category/names")]
        [HttpGet]
        public List<string> Nemes()
        {
            return NewsCategoryService.GetNames();
        }
    }
}

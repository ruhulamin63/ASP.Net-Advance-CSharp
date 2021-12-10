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
    public class NewsController : ApiController
    {
        [Route("api/get/news/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = NewsService.GetAll();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
        }

        [Route("api/get/news/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = NewsService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/add/news")]
        [HttpPost]
        public IHttpActionResult Add(NewsModel n)
        {
            if (NewsService.Add(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("api/edit/category/{id}")]
        [HttpPost]
        public IHttpActionResult Edit(NewsModel n)
        {
            if (NewsService.Edit(n))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("api/delete/news/{id}")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            if (NewsService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [Route("api/get/news/bydate/{datetime}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] DateTime dateTime)
        {
            var data = NewsService.GetByDate(dateTime);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/get/news/bycategory/{id}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var data = NewsService.GetByCategory(id);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/get/news/bydate/category/{category}")]
        [HttpGet]
        public IHttpActionResult GetDateCategory([FromUri] DateTime dateTime, [FromUri] string category)
        {
            var data = NewsService.GetByDateCategory(dateTime, category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}

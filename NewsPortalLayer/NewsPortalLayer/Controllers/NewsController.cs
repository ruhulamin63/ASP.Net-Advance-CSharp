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
        public IHttpActionResult Get()
        {
            var data = NewsService.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
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
        
        [Route("api/get/news/bydate")]
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

        [Route("api/get/news/bycategory")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] string category)
        {
            var data = NewsService.GetByCategory(category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [Route("api/get/news/bydate/category")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] DateTime dateTime, [FromUri] string category)
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

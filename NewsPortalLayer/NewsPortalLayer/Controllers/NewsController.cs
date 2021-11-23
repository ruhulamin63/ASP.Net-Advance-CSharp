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
        [Route("api/News/All")]
        [HttpGet]
        public List<NewsModel> GetAll()
        {
            return NewsService.GetAll();
        }
    }
}

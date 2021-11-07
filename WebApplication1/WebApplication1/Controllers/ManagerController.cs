using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult List()
        {
            var p = ServiceRepository.GetAll();

            return View(p);
        }

           // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult manage_services_list()
        {
            //var db = new Entities();

            var s = ServiceRepository.GetAll();

            return View(s);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Home_service_asp_net_mvc_project.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult manage_services()
        {
            return View();
        }
    }
}
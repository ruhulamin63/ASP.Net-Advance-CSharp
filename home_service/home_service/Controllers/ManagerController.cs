using home_service.Models.EntityFramwork;
using home_service.Models.ManagerViewModel;
using home_service.ManagerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace home_service.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Service_List()
        {
            var p = ServiceRepository.GetAll();

            return View(p);
        }

        [HttpGet]
        public ActionResult Service_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Service_Create(Service s)
        {
            var db = new ShebaDbEntities();
            db.Services.Add(s);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Service_Edit(int id)
        {
            var db = new ShebaDbEntities();
            var product = (from p in db.Services
                           where p.id == id
                           select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Service_Edit(Service pro)
        {
            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var product = (from p in db.Services
                           where p.id == pro.id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pro);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
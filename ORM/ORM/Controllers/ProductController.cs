using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            var db = new ProductEntities1();

            var data = db.products.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(product s)
        {
            var db = new ProductEntities1();
            db.products.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            return View();
        }
    }
}
using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Product_MS.Models;

namespace Product_MS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.Get();

            return View(products);
        }


        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("List");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Update(p);
                return RedirectToAction("List");
            }
            return View(p);
        }

        
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            var res = db.Products.Delete(id);

            return RedirectToAction("List",res);
        }
    }
}
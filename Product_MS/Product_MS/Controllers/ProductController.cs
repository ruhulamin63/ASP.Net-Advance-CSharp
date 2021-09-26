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
            Product s = new Product();
            return View(s);
        }

        [HttpPost]
        public ActionResult Create(Product s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(s);
                return RedirectToAction("List");
            }
            return View(s);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
    }
}
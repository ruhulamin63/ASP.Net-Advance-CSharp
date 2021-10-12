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

            var db = new ProductEntities();

            List<product> data = db.products.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(product s)
        {
            var db = new ProductEntities();
            db.products.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var db = new ProductEntities();
            var product = (from p in db.products where p.Id == id
                           select p).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(product pro)
        {
            var db = new ProductEntities();

           /* product.Name = pro.Name*/

            var product = (from p in db.products
                           where p.Id == pro.Id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pro);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(product pro)
        {
            var db = new ProductEntities();
            var product = (from p in db.products
                           where p.Id == pro.Id
                           select p).FirstOrDefault();
            db.products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
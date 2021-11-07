using E_Commerce.Auth;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [AllowAnonymous] //not authorize
        public ActionResult Index()
        {
            var db = new ProductEntities();

            List<product> data = db.products.ToList();
            return View(data);
        }

        [VerifyAdmin]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [VerifyAdmin]
        [HttpPost]
        public ActionResult Create(product s)
        {
            var db = new ProductEntities();
            db.products.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

      /*  [VerifyAdmin]*/
        public ActionResult Edit(int id)
        {
            var db = new ProductEntities();
            var product = (from p in db.products
                           where p.Id == id
                           select p).FirstOrDefault();
            return View(product);
        }

        /*[VerifyAdmin]*/
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

        [VerifyAdmin]
        [HttpPost]
        public ActionResult Delete(product pro)
        {
            var db = new ProductEntities();
            var product = (from p in db.products
                           where p.Id == pro.Id
                           select p).FirstOrDefault();
            db.products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }


        public ActionResult Order()
        {
            var db = new ProductEntities();
            //var products = db.products.Get();

            return View();
        }

    }
}
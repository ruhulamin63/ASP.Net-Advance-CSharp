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
    //[VerifyCustomer]
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

        [VerifyAdmin]
        public ActionResult Edit(int id)
        {
            var db = new ProductEntities();
            var product = (from p in db.products
                           where p.Id == id
                           select p).FirstOrDefault();
            return View(product);
        }

        [VerifyAdmin]
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

        [HttpGet]
        public ActionResult Cart(int id)
        {
            var db = new ProductEntities();
            var p = db.products.Find(id);

            if (p != null)
            {
                List<product> products = new List<product>();

                if (Session["cart"] == null)
                {
                    products.Add(p);

                    string json = new JavaScriptSerializer().Serialize(products);
                    Session["cart"] = json;

                    return RedirectToAction("Cart_Index");
                }
                else
                {
                    string json = Session["cart"].ToString();
                    var val = new JavaScriptSerializer().Deserialize<List<product>>(Session["cart"].ToString());
                    val.Add(p);

                    json = new JavaScriptSerializer().Serialize(val);
                    Session["cart"] = json;

                    return RedirectToAction("Index", "Product");
                }
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Cart_Index()
        {
            if (Session["cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<product>>(Session["cart"].ToString());
                return View(products);
            }
            Session["test"] = "ok";
            return Redirect("/product/indext");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (Session["cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<product>>(Session["cart"].ToString());
                var productToRemove = products.Single(p => p.Id == id);
                products.Remove(productToRemove);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
            }
            return RedirectToAction("Cart_Index");
        }
    }
}
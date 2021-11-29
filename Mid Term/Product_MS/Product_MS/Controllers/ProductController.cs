using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Product_MS.Models;
using System.Web.Script.Serialization;
using Product_MS.Auth;

namespace Product_MS.Controllers
{
   /* [Authorize] //all function are authorize*/

    [AdminAccess]

    public class ProductController : Controller
    {
        // GET: Product
       [AllowAnonymous] //not authorize

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
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
             db.Products.Delete(id);

            return RedirectToAction("List");
        }

        public ActionResult Order()
        {
            Database db = new Database();
            var products = db.Products.Get();

            return View(products);
        }

        [HttpGet]
        public ActionResult Cart(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);

            if(p != null)
            {
                List<Product> products = new List<Product>();

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
                    var val = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                    val.Add(p);

                    json = new JavaScriptSerializer().Serialize(val);
                    Session["cart"] = json;

                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Cart_Index()
        {
            if (Session["cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                return View(products);
            }
            Session["test"] = "ok";
            return Redirect("/product/list");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (Session["cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                var productToRemove = products.Single(p => p.Id == id);
                products.Remove(productToRemove);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["cart"] = json;
            }
            return RedirectToAction("Cart_Index");
        }
    }
}
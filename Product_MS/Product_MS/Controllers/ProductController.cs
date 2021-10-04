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


            /*List<Product> products = new List<Product>();
            

            string json = new JavaScriptSerializer().Serialize(products);
            Session["Cart"] = json;
            return View(p);*/

            if (Session["Cart"] == null)
            {
                List<Product> products = new List<Product>();
                products.Add(p);

                string json = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = json;
            }
            else
            {
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                products.Add(p);

                string json = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = json;
            }
            /*return RedirectToAction("Cart_Index");*/
            return View(p);
        }

        [HttpGet]
        public ActionResult Cart_Index()
        {
            Database db = new Database();
            var products = db.Products.Get();

           /* List<Product> products = new List<Product>();*/
            if (Session["Cart"] != null)
            {
                products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                return View(products);
            }
            return View(products);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (Session["Cart"] != null)
            {
                var products = new JavaScriptSerializer().Deserialize<List<Product>>(Session["Cart"].ToString());
                var productToRemove = products.Single(p => p.Id == id);
                products.Remove(productToRemove);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = json;
            }
            return RedirectToAction("Cart_Index");
        }

        /*public ActionResult Remove(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }*/
    }
}
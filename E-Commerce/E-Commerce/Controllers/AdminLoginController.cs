using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace E_Commerce.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
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
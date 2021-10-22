using ecomm.Models.VM;
using ecomm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ecomm.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //var db = new Entities();

            var p = ProductRepository.GetAll();

            return View(p);
        }

        public ActionResult AddToCart(int id)
        {
            var pm = ProductRepository.Get(id);

            List<ProductModel> products;

            if (Session["cart"] == null)
            {
                products = new List<ProductModel>();
            }
            else
            {
                var json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            }
            products.Add(pm);

            var json2 = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json2;

            return RedirectToAction("Index", "Product");
        }

        public ActionResult Cart()
        {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);

            return View(products);
        }

        public ActionResult Checkout()
        {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);

            var cid = 1; //User.Identity.Name => I pencipal class instance from cookei file

            OrderRepository.PlaceOrder(products, cid);

            Session.Remove("cart");

            return RedirectToAction("Index");
        }

        public ActionResult MyOrders()
        {
            var cId = 1; //User.Identity.Name

            var orders = OrderRepository.MyOrders(cId);

            return View(orders);
        }
    }
}
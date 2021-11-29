
using Product_MS.Models;
using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture_3.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Place(List<Product> products)
        {
            string orderId = Guid.NewGuid().ToString();
            foreach (var product in products)
            {
                Database db = new Database();
                /* db.Orders.Place(orderId, product.Id, product.Price);*/
            }
            return RedirectToAction("Index");
        }
    }
}
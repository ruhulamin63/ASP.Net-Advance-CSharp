using Add_To_Card_for_Product_Application.Models;
using LearnASPNETMVCWithRealApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Add_To_Card_for_Product_Application.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.products = productModel.findAll();

            return View();
        }
    }
}
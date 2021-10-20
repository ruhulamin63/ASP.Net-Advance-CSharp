using E_Commerce.Auth;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    [VerifyCustomer]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var db = new ProductEntities();

            List<customer> data = db.customers.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var db = new ProductEntities();
            var data = (from d in db.customers
                        where d.Id == id
                        select d).FirstOrDefault();

            return View(data);
        }
    }
}
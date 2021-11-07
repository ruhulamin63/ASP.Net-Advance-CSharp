using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Ghor_Sheba.Models;
using Newtonsoft.Json;

namespace Ghor_Sheba.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewServices(int id)
        {

            string catg = "";
            if(id==1)
            {
                catg = "Home Cleaning";
            }
            else if(id==2)
            {
                catg = "Appliance Repair";
            }
            else if(id==3)
            {
                catg = "Pest Control";
            }
            else if(id==4)
            {
                catg = "Plumbing";
            }
            else if(id==5)
            {
                catg = "Ac Services";
            }


            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                        where data.category.Trim() == catg
                        select data).ToList();
            return View(serv);
   
        }

        public ActionResult AddToList(int id)
        {
            var db = new ShebaDbEntities();
            var serv = (from data in db.Services
                        where data.id == id
                        select data).FirstOrDefault();

            if(Session["cart"]==null)
            {
                List<Service> Services = new List<Service>();
                Services.Add(serv);
                string json = JsonConvert.SerializeObject(Services);
                Session["cart"] = json;
            }
            else
            {
                var d = JsonConvert.DeserializeObject<List<Service> >(Session["cart"].ToString());
                d.Add(serv);
                string json = JsonConvert.SerializeObject(d);
                Session["cart"] = json;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
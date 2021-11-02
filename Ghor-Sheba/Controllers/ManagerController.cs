using Ghor_Sheba.Auth;
using Ghor_Sheba.ManagerRepository;
using Ghor_Sheba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Ghor_Sheba.Controllers
{
    [ManagerAccess]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            return View();
        }

    //================================================================================================

        // GET: Manager
        public ActionResult Service_List()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = ServiceRepository.GetAll();

            return View(p);
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Service_Create()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            return View();
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Service_Create(Service s)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();
            db.Services.Add(s);
            db.SaveChanges();

            return RedirectToAction("Service_List");
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Service_Edit(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();
            var product = (from p in db.Services
                           where p.id == id
                           select p).FirstOrDefault();
            return View(product);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Service_Edit(Service pro)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var product = (from p in db.Services
                           where p.id == pro.id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pro);
            db.SaveChanges();

            return RedirectToAction("Service_List");
        }


    //================================================================================================

        [HttpGet]
        public ActionResult Service_Delete(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var bcr = ServiceRepository.Get(id);

            return View(bcr);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Service_Delete(Service user)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            var serivie = (from p in db.Services
                           where p.id == user.id
                           select p).FirstOrDefault();

            db.Services.Remove(serivie);
            db.SaveChanges();

            return RedirectToAction("Service_List", "Manager");
        }



        //================================================================================================
        //Booking View Page

        public ActionResult Booking_List()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = BookingRepository.GetAll();

            return View(p);
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Booking_Create()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            return View();
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Booking_Create(Booking s)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();
            db.Bookings.Add(s);
            db.SaveChanges();

            return RedirectToAction("Booking_List");
        }

     //================================================================================================

        [HttpGet]
        public ActionResult Booking_Edit(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();
            var product = (from p in db.Bookings
                           where p.id == id
                           select p).FirstOrDefault();
            return View(product);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Booking_Edit(Booking pro)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var product = (from p in db.Bookings
                           where p.id == pro.id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pro);
            db.SaveChanges();

            return RedirectToAction("Booking_List");
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Booking_Delete(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var bcr = BookingRepository.Get(id);

            return View(bcr);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Booking_Delete(LoginUser user)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            var booking = (from p in db.Bookings
                           where p.id == user.id
                           select p).FirstOrDefault();

            db.Bookings.Remove(booking);
            db.SaveChanges();

            return RedirectToAction("Booking_List", "Manager");
        }


    //================================================================================================
    //Complaint Customer View Page

        public ActionResult Complaint_List()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = ComplaintRepository.GetAll();

            return View(p);
        }


        public ActionResult Complaint_Received(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            var b = (from bk in db.Complaints
                     where bk.id == id && bk.status == "unread"
                     select bk).FirstOrDefault();

            if (b != null)
            {
                ComplaintRepository.Unread_to_Read(id);
            }

            return RedirectToAction("Complaint_List", "Manager");

        }


        //================================================================================================
        //Service Provider View Page

        public ActionResult Service_Provider_List()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = ServiceProviderRepository.GetAll();

           /* var db = new ShebaDbEntities();
            var sp = (from data in db.service_provider_status
                      where data.status == "available"
                      select data).ToList();*/

            return View(p);
        }

        public ActionResult Service_Provider_Get_Id_List(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            Session["b_id"] = id;

            //var p = ServiceProviderRepository.GetAll();

            return View();
        }

    //================================================================================================
        /*
        public ActionResult AddToCart(int id)
        {
            var spr = ServiceProviderRepository.Get(id);

            List<ServiceProviderModel> spm;

            if (Session["cart"] == null)
            {
                spm = new List<ServiceProviderModel>();
            }
            else
            {
                var json = Session["cart"].ToString();
                spm = new JavaScriptSerializer().Deserialize<List<ServiceProviderModel>>(json);
            }
            spm.Add(spr);

            var json2 = new JavaScriptSerializer().Serialize(spm);
            Session["cart"] = json2;

            return RedirectToAction("Cart", "Manager");
        }*/

    //================================================================================================

        /* public ActionResult Cart()
         {
             var json = Session["cart"].ToString();
             var spm = new JavaScriptSerializer().Deserialize<List<ServiceProviderModel>>(json);

             return View(spm);
         }*/

        //================================================================================================

        public ActionResult Confirm(int service_provider_id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            /* var json = Session["cart"].ToString();
             var spm = new JavaScriptSerializer().Deserialize<List<ServiceProviderModel>>(json);*/

            //var bid = 1; //User.Identity.Name => I pencipal class instance from cookei file

            var id = Session["b_id"].ToString();
            int b_id = Int32.Parse(id);

            //var sp_id = Session["cart"];*/

            ServiceAssignRepository.PlaceAssignServiceProvider(b_id, service_provider_id);
           /* var db = new ShebaDbEntities();

            var cs = new Booking_confirms()
            {
                booking_id = Int32.Parse(id),
                service_provider_id = sp_id,
                status = "busy"
            };
            db.Booking_confirms.Add(cs);
            db.SaveChanges();*/

            Session.Remove("b_id");


            return RedirectToAction("Service_Provider_List", "Manager");
        }

        //================================================================================================

        public ActionResult Service_Provider_Assign(int bId)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            //var bId = 1; //User.Identity.Name

            var sps = ServiceAssignRepository.MyServiceProviderAssign(bId);

            return View(sps);
        }

        //================================================================================================

        /*public ActionResult DeleteToCart(int id)
        {
            var jsonString = Session["cart"].ToString();
            var data = new JavaScriptSerializer().Deserialize<List<ServiceProviderModel>>(jsonString);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] != null)
                    if (data[i].id == id && data[i] != null)
                    {
                        data[i] = null;
                    }
            }
            Session["cart"] = new JavaScriptSerializer().Serialize(data);

            return RedirectToAction("Cart");

        }*/

    //================================================================================================
    //Booingk Confirm Information

        public ActionResult Booking_Confirm_List()
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = BookingConfirmRepository.GetAll();

            return View(p);
        }

    //================================================================================================

        public ActionResult Booking_Confirm_Details(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var p = ServiceAssignRepository.MyServiceProviderAssign(id);

            return View(p);
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Booking_Confirm_Edit(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();
            var result = (from p in db.Booking_confirms
                           where p.id == id
                           select p).FirstOrDefault();
            return View(result);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Booking_Confirm_Edit(LoginUser get)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var result = (from p in db.Booking_confirms
                           where p.id == get.id
                           select p).FirstOrDefault();

            db.Entry(result).CurrentValues.SetValues(get);
            db.SaveChanges();

            return RedirectToAction("Booking_Confirm_List");
        }

    //================================================================================================

        [HttpGet]
        public ActionResult Booking_Confirm_Delete(int id)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var bcr = BookingConfirmRepository.Get(id);

            return View(bcr);
        }

    //================================================================================================

        [HttpPost]
        public ActionResult Booking_Confirm_Delete(LoginUser user)
        {
            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            var db = new ShebaDbEntities();

            var booking = (from p in db.Booking_confirms
                           where p.id == user.id
                           select p).FirstOrDefault();

            db.Booking_confirms.Remove(booking);
            db.SaveChanges();

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

    //================================================================================================
    //Profile Information

        [HttpGet]
        public ActionResult MyProfile()
        {
            /* object u_id = Session["userid"];*/

            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            int u_id = 2;
            //var id = u_id;
            var user = ManagerProfileRepository.GetProfileInfo(u_id);
            return View(user);
        }

    //================================================================================================

        [HttpGet]
        public ActionResult EditProfile()
        {
            /*object u_id = Session["userid"];*/

            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            int id = 2;
            var user = ManagerProfileRepository.GetEditInfo(id);
            return View(user);

        }

    //================================================================================================

        [HttpPost]
        public ActionResult EditProfile(LoginUser user)
        {
            //var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();

                entity.username = user.username.Trim();
                entity.phone = user.phone.Trim();
                entity.email = user.email.Trim();
                entity.address = user.address.Trim();
                entity.fullname = user.fullname.Trim();

                db.SaveChanges();
                return RedirectToAction("MyProfile");
            }
        }
        //================================================================================================


        [HttpGet]
        public ActionResult Change_Password()
        {
            /*object u_id = Session["userid"];*/

            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            int id = 2;
            var user = ManagerProfileRepository.Get_Password_Info(id);

            return View(user);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Change_Password(LoginUser user)
        {
            //var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var data = User.Identity.Name;
            var json = JsonConvert.DeserializeObject<LoginUser>(data.ToString());
            ViewData["username"] = json.username;

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                var entity = (from u in db.LoginUsers
                              where u.id == user.id
                              select u).FirstOrDefault();

                entity.password = user.password.Trim();

                db.SaveChanges();
                return RedirectToAction("MyProfile");
            }
        }
    }
}
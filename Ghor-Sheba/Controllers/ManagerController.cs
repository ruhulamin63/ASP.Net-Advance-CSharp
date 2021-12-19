using Ghor_Sheba.Auth;
using Ghor_Sheba.ManagerRepository;
using Ghor_Sheba.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ghor_Sheba.Controllers
{
    [ManagerAccess]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            var db = new ShebaDbEntities();

            var email = User.Identity.Name;
            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();

            var result = LoginUserRepository.GetAll();

            ViewData["username"] = user.username;

            return View(result);
        }

        //================================================================================================

        // GET: Manager
        public ActionResult Service_List()
        {
            var p = ServiceRepository.GetAll();

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View(p);
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Service_Create()
        {
            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View();
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Service_Create(Service s)
        {
            var db = new ShebaDbEntities();
            db.Services.Add(s);
            db.SaveChanges();

            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return RedirectToAction("Service_List");
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Service_Edit(int id)
        {
            var db = new ShebaDbEntities();
            var product = (from p in db.Services
                           where p.id == id
                           select p).FirstOrDefault();

            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View(product);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Service_Edit(Service pro)
        {
            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var product = (from p in db.Services
                           where p.id == pro.id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pro);
            db.SaveChanges();

            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return RedirectToAction("Service_List");
        }


        //================================================================================================

        [HttpGet]
        public ActionResult Service_Delete(int id)
        {
            var bcr = ServiceRepository.Get(id);

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(bcr);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Service_Delete(Service user)
        {
            var db = new ShebaDbEntities();

            var serivie = (from p in db.Services
                           where p.id == user.id
                           select p).FirstOrDefault();

            db.Services.Remove(serivie);
            db.SaveChanges();

            var email = User.Identity.Name;

            var u = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = u.username;

            return RedirectToAction("Service_List", "Manager");
        }



        //================================================================================================
        //Booking View Page

        public ActionResult Booking_List()
        {
            var p = BookingRepository.GetAll();

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(p);
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Booking_Create()
        {
            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View();
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Booking_Create(Booking s)
        {
            var db = new ShebaDbEntities();
            db.Bookings.Add(s);
            db.SaveChanges();


            return RedirectToAction("Booking_List");
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Booking_Edit(int id)
        {
            var db = new ShebaDbEntities();
            var product = (from p in db.Bookings
                           where p.id == id
                           select p).FirstOrDefault();

            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View(product);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Booking_Edit(Booking pro)
        {
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
            var bcr = BookingRepository.Get(id);

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(bcr);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Booking_Delete(LoginUser user)
        {
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
            var p = ComplaintRepository.GetAll();

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(p);
        }


        public ActionResult Complaint_Received(int id)
        {
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

        [HttpGet]
        public ActionResult Service_Provider_List()
        {
            //Session["b_id"] = id;

            var sp = ServiceProviderRepository.GetAll();

            /* var db = new ShebaDbEntities();
             var em = User.Identity.Name;
             em = em.Trim();
             var user = (from data in db.LoginUsers
                         where data.email.Trim() == em
                         select data).FirstOrDefault();

             ViewData["username"] = user.username;

             var sp = (from data in db.service_provider_status
                       where data.status.Trim() == "available"
                       select data).ToList();

             Session["confirm_booking"] = id;*/

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(sp);
        }


        public ActionResult Service_Provider_Ger_Id(int id)
        {
            /*var sp = (from data in db.service_provider_status
                      where data.status.Trim() == "available"
                      select data).ToList();*/

            var sp = ServiceProviderRepository.GetAll();

            Session["confirm_booking"] = id;

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return View(sp);
        }

        //================================================================================================

        /*public ActionResult AddToCart(int id)
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

        [HttpGet]
        public ActionResult Confirm(int sp_id)
        {
            /*var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ServiceProviderModel>>(json);

            //var cid = 4; //User.Identity.Name => I pencipal class instance from cookei file
            //object id = Session["b_id"];
            int b_id = 4;

            ServiceAssignRepository.PlaceAssignServiceProvider(products, b_id);*/


            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            string id1 = Session["confirm_booking"].ToString();

            var cs = new Booking_confirms()
            {
                booking_id = Int32.Parse(id1),
                service_provider_id = sp_id,
                status = "confirm"
            };

            var book = (from data in db.Bookings
                        where data.id == cs.booking_id
                        select data).FirstOrDefault();

            var temp = book;
            temp.status = "confirm";
            db.Entry(book).CurrentValues.SetValues(temp);
            db.SaveChanges();
            db.Booking_confirms.Add(cs);
            db.SaveChanges();

            ServiceAssignRepository.Unassign_to_assign(sp_id);
            Session.Remove("confirm_booking");

            return RedirectToAction("Booking_Confirm_List");
        }

        //================================================================================================

        public ActionResult Service_Provider_Assign(int bId)
        {
            //var bId = 1; //User.Identity.Name

            var sps = ServiceAssignRepository.MyServiceProviderAssign(bId);

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

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
            var p = BookingConfirmRepository.GetAll();

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            return View(p);
        }

        //================================================================================================

        public ActionResult Booking_Confirm_Details(int id)
        {
            var p = ServiceAssignRepository.MyServiceProviderAssign(id);

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return View(p);
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Booking_Confirm_Edit(int id)
        {
            var db = new ShebaDbEntities();
            var result = (from p in db.Booking_confirms
                          where p.id == id
                          select p).FirstOrDefault();

            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;
            return View(result);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Booking_Confirm_Edit(LoginUser get)
        {
            var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

            var result = (from p in db.Booking_confirms
                          where p.id == get.id
                          select p).FirstOrDefault();

            db.Entry(result).CurrentValues.SetValues(get);
            db.SaveChanges();

            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return RedirectToAction("Booking_Confirm_List");
        }

        //================================================================================================

        [HttpGet]
        public ActionResult Booking_Confirm_Delete(int id)
        {
            var bcr = BookingConfirmRepository.Get(id);

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return View(bcr);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Booking_Confirm_Delete(LoginUser user)
        {
            var db = new ShebaDbEntities();

            var booking = (from p in db.Booking_confirms
                           where p.id == user.id
                           select p).FirstOrDefault();

            db.Booking_confirms.Remove(booking);
            db.SaveChanges();

            var em = User.Identity.Name;
            em = em.Trim();
            var u = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();

            ViewData["username"] = u.username;

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

        //================================================================================================
        //Profile Information

        [HttpGet]
        public ActionResult MyProfile()
        {
            /* object u_id = Session["userid"];*/

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();

            int u_id = user.id;
            //var id = u_id;
            var result = ManagerProfileRepository.GetProfileInfo(u_id);

            ViewData["username"] = user.username;

            return View(result);
        }

        //================================================================================================

        [HttpGet]
        public ActionResult EditProfile()
        {
            /*object u_id = Session["userid"];*/

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
       

            int id = user.id;
            var result = ManagerProfileRepository.GetEditInfo(id);

            ViewData["username"] = user.username;
            return View(result);

        }

        //================================================================================================

        [HttpPost]
        public ActionResult EditProfile(LoginUser user)
        {
            //var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

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

            var db = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in db.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();
        

            int id = user.id;
            var result = ManagerProfileRepository.Get_Password_Info(id);

            ViewData["username"] = user.username;
            return View(result);
        }

        //================================================================================================

        [HttpPost]
        public ActionResult Change_Password(LoginUser user)
        {
            //var db = new ShebaDbEntities();

            /* product.Name = pro.Name*/

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

        //================================================================================================
        /*
                [HttpGet]
                public ActionResult Image_Upload()
                {
                    return View();
                }

                [HttpPost]
                public ActionResult Image_Upload(LoginUsers imageModel)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                    string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    imageModel.image = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    imageModel.ImageFile.SaveAs(fileName);
                    using (ShebaDbEntities db = new ShebaDbEntities())
                    {
                        db.LoginUsers.Add(imageModel);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    return View();
                }*/
        //================================================================================================

        public ActionResult ManageBookedService()
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var booking = (from data in db.Bookings
                           where data.status.Trim() == "pending"
                           select data).ToList();
            return View(booking);
        }

        public ActionResult ConfirmBookedService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();
            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var sp = (from data in db.service_provider_status
                      where data.status.Trim() == "available"
                      select data).ToList();
            Session["confirm_booking"] = id;
            return View(sp);
        }

        public ActionResult DeleteBookedService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;
            var book = (from data in db.Bookings
                        where data.id == id
                        select data).FirstOrDefault();

            var bookdt = (from data in db.Booking_details
                          where data.booking_id == id
                          select data).ToList();

            foreach (var p in bookdt)
            {
                db.Booking_details.Remove(p);
                db.SaveChanges();
            }

            db.Bookings.Remove(book);
            db.SaveChanges();

            return RedirectToAction("ManageBookedService", "Admin");
        }

        public ActionResult EditBookedService(int id)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var book = (from data in db.Bookings
                        where data.id == id
                        select data).FirstOrDefault();

            return View(book);
        }

        [HttpPost]
        public ActionResult EditBookedService(Booking b)
        {
            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            var book = (from data in db.Bookings
                        where data.id == b.id
                        select data).FirstOrDefault();

            db.Entry(book).CurrentValues.SetValues(b);
            db.SaveChanges();
            return View(book);
        }

        public ActionResult AssignServiceProvider(int id)
        {

            var db = new ShebaDbEntities();
            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            string id1 = Session["confirm_booking"].ToString();

            var cs = new Booking_confirms()
            {
                booking_id = Int32.Parse(id1),
                service_provider_id = id,
                status = "confirm"
            };

            var book = (from data in db.Bookings
                        where data.id == cs.booking_id
                        select data).FirstOrDefault();

            var temp = book;
            temp.status = "confirm";
            db.Entry(book).CurrentValues.SetValues(temp);
            db.SaveChanges();
            
            db.Booking_confirms.Add(cs);
            db.SaveChanges();

            var sp = (from data in db.service_provider_status
                      where data.service_provider_id == id
                      select data).First();
            sp.status = "busy";
            db.SaveChanges();

            return RedirectToAction("ManageBookedService", "Admin");
        }

        public ActionResult ViewDetails(int id)
        {
            var db = new ShebaDbEntities();

            var det = (from data in db.Booking_details
                       where data.booking_id == id
                       select data).ToList();

            var slist = new List<Service>();

            foreach (var p in det)
            {
                var x = (from data in db.Services
                         where data.id == p.service_id
                         select data).FirstOrDefault();
                slist.Add(x);
            }

            var em = User.Identity.Name;
            em = em.Trim();

            var user = (from data in db.LoginUsers
                        where data.email.Trim() == em
                        select data).FirstOrDefault();
            ViewData["username"] = user.username;

            return View(slist);
        }

        //================================================================================================
        //change profile photos

        [HttpGet]
        public ActionResult Add()
        {
            var database = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in database.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return View();
        }

        /*[HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.image_path = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();

            return RedirectToAction("Image_View");
        }

        [HttpGet]
        public ActionResult Image_View(int id)
        {
            Image imageModel = new Image();

            using (ShebaDbEntities db = new ShebaDbEntities())
            {
                imageModel = db.Images.Where(x => x.id == id).FirstOrDefault();
            }

            var database = new ShebaDbEntities();
            var email = User.Identity.Name;

            var user = (from data in database.LoginUsers
                        where data.email == email
                        select data).FirstOrDefault();

            ViewData["username"] = user.username;

            return View(imageModel);
        }*/

    }
}
using BEL;
using BEL.ManagerModel;
using BLL;
using FrontEnd.GlobalVariables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserAllData()
        {
            var users = new List<UserModel>();

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("api/users/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersData = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserModel>>(usersData);
            }
            return View(users);
        }

        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserModel user)
        {
            //u.usertype = "Customer";
            //u.verification_status = "0";
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/users/create", user).Result;
                //return View(user);
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        public ActionResult UserEdit(int id)
        {
            var user = new UserModel();
            string path = "api/users/" + id;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UserEdit(UserModel user)
        {
            if(ModelState.IsValid)
{
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/users/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        public ActionResult UserDelete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("api/users/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }



        //===========================Booking Function================================

        public ActionResult Booking_List()
        {
            var users = new List<BookingModel>();

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("api/booking/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var usersData = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<BookingModel>>(usersData);
            }
            return View(users);
        }

        public ActionResult Booking_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booking_Create(BookingModel booked)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/booking/create", booked).Result;
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Booking_List", "Manager");
        }

        public ActionResult Booking_Edit(int id)
        {
            var user = new BookingModel();
            string path = "api/booking/" + id;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<BookingModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Booking_Edit(BookingModel user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/booking/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("UserAllData", "Manager");
        }

        public ActionResult Booking_Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("api/booking/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("Booking_List", "Manager");
        }


        //==========================Booking Confirm Function=========================================

        public ActionResult Booking_Confirm_List()
        {
            var booked = new List<BookingDetailsModel>();

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("api/booking/confirm/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var bookingData = response.Content.ReadAsStringAsync().Result;
                booked = JsonConvert.DeserializeObject<List<BookingDetailsModel>>(bookingData);
            }
            return View(booked);
        }

        public ActionResult Booking_Confirm_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booking_Confirm_Create(BookingDetailsModel booked)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/booking/confirm/create", booked).Result;
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

        public ActionResult Booking_Confirm_Edit(int id)
        {
            var user = new BookingDetailsModel();
            string path = "api/booking/confirm/" + id;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<BookingDetailsModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Booking_Confirm_Edit(BookingDetailsModel user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/booking/confirm/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("Boonking_Confirm_List", "Manager");
        }

        public ActionResult Booking_Confirm_Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("api/booking/confirm/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("Booking_Confirm_List", "Manager");
        }

        //==========================Services Function=========================================

        public ActionResult Service_List()
        {
            var service = new List<ServiceModel>();

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("api/service/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var serviceData = response.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<List<ServiceModel>>(serviceData);
            }
            return View(service);
        }

        public ActionResult Service_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Service_Create(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/service/create", service).Result;
            }

            TempData["SuccessMessage"] = "Create Successfully";

            return RedirectToAction("Service_List", "Manager");
        }

        public ActionResult Service_Edit(int id)
        {
            var user = new ServiceModel();
            string path = "api/service/" + id;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var Response = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<ServiceModel>(Response);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Service_Edit(ServiceModel user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("api/service/edit", user).Result;
            }
            TempData["SuccessMessage"] = "Update Successfully";

            return RedirectToAction("Service_List", "Manager");
        }

        public ActionResult Service_Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("api/service/delete/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";

            return RedirectToAction("Service_List", "Manager");
        }


        //===================Complain Function=======================================

        public ActionResult Review_List()
        {
            var review = new List<ReviewModel>();

            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("api/review/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var reviewData = response.Content.ReadAsStringAsync().Result;
                review = JsonConvert.DeserializeObject<List<ReviewModel>>(reviewData);
            }
            return View(review);
        }


        //====================================Profile===================================

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}
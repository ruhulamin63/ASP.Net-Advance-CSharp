using BEL;
using FrontEnd.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [ServiceProviderAccess]
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditServiceProvider()
        {
            var sp = new ServUserModel();
            int id = Int32.Parse(Session["u_id"].ToString());
            string path = "api/ServiceProvider/Profile/" + id.ToString();

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<ServUserModel>(ServiceProviderResponse);
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult EditServiceProvider(ServUserModel u)
        {

            TempData["AlertMessage"] = "Sucessfully Updated";

            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/ServiceProvider/Profile", u).Result;

            return View(u);
        }
        public ActionResult ViewBooking()
        {
            string token = Session["token"].ToString();
            int id = Int32.Parse(Session["u_id"].ToString());
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ServiceProvider/ViewBooking/"+id.ToString()).Result;
            var b = new List<BookingModel>();

            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                b = JsonConvert.DeserializeObject<List<BookingModel>>(ServiceProviderResponse);
            }
            return View(b);
        }

        public ActionResult EditBooking(int id)
        {
            var sb = new Book_Bookingser();
            string path = "api/ServiceProvider/Bookedit/" + id;


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                sb = JsonConvert.DeserializeObject<Book_Bookingser>(ServiceProviderResponse);
            }
            return View(sb);

        }

        [HttpPost]
        public ActionResult EditBooking(Book_Bookingser u)
        {

            TempData["AlertMessage"] = "Sucessfully Updated";


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/ServiceProvider/Bookedit", u).Result;

            return View(u);
        }

        public ActionResult CheckReview()
        {
            var serviceProvider = new List<SerReviewModel>();


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ServiceProvider/CheckReview").Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                serviceProvider = JsonConvert.DeserializeObject<List<SerReviewModel>>(ServiceProviderResponse);
            }

            return View(serviceProvider);
        }

        public ActionResult CheckBonus(int id)
        {
            var sb = new ServiceProviderBonusModel();
            string path = "api/ServiceProvider/CheckBonus/" + id;


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                sb = JsonConvert.DeserializeObject<ServiceProviderBonusModel>(ServiceProviderResponse);
            }
            return View(sb);

        }

        public ActionResult WorkDetail(int id)
        {
            var bd = new List<AdminBookingDetailModel>();
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ServiceProvider/WorkDetail/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                bd = JsonConvert.DeserializeObject<List<AdminBookingDetailModel>>(ServiceProviderResponse);
            }

            return View(bd);

        }

        public ActionResult ShowDetail()
        {
            int u_id = Int32.Parse(Session["u_id"].ToString());

            var serviceProvider = new List<ServiceDetailModel>();


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ServiceProvider/ServiceDetail/"+u_id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                serviceProvider = JsonConvert.DeserializeObject<List<ServiceDetailModel>>(ServiceProviderResponse);
            }

            return View(serviceProvider);
        }

        public ActionResult StatusOfAvailability()
        {
            int u_id = Int32.Parse(Session["u_id"].ToString());
            var sp = new ServUserModel();
            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/ServiceProvider/Profile/"+u_id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                var ServiceProviderResponse = response.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<ServUserModel>(ServiceProviderResponse);
                
            }

            return View(sp);
        }

        [HttpPost]
        public ActionResult StatusOfAvailability(ServiceProviderModel u)
        {

            TempData["AlertMessage"] = "Sucessfully Updated";


            string token = Session["token"].ToString();
            GlobalVariables.WebApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/ServiceProvider/WorkStatus", u).Result;

            return RedirectToAction("EditServiceProvider", "ServiceProvider");
        }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab_Task_2.Models;

namespace Lab_Task_2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.name = "Ruhul Amin";

            string[] names = new string[5];

            names[0] = "Ruhul";
            names[1] = "Hridoy";

            ViewBag.name = names;
      
            return View();
        }
        
        public ActionResult Create()
        {
            Student obj = new Student()
            {
                id = 12,
                name = "Amin",
                dob = "12-34-12"
            };
            return View(obj);       
        }
        
        public ActionResult List()
        {
            List<Student> students = new List<Student>();

            for(int i=0; i<10; i++)
            {
                Student obj1 = new Student()
                {
                    id = 13 + (i + 1),
                    name = "Ruhul Amin",
                    dob = "12-34-54"
                };
                students.Add(obj1);
            }
            return View(students);
        }

        public ActionResult CreateSubmit(Student s)
        {
            //return RedirectToAction("List");

           // ViewBag.name = Request["name"].ToString();
            //ViewBag.id = Request["id"].ToString();

            return View(s);
        }
        
    }
}
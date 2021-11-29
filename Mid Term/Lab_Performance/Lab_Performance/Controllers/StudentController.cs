using Lecture_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
namespace Lecture_3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            string connString = @"Server=DESKTOP-JOQNJEJ\SQLEXPRESS; Database=student; Password=needhelp;  Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "select * from students";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student s = new Student()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                   // Cgpa = (double)reader.GetDouble(reader.GetOrdinal("Cgpa"))

                };
                students.Add(s);
            }

            conn.Close();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Student s = new Student();
            return View(s);
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                string connString = @"Server=DESKTOP-JOQNJEJ\SQLEXPRESS; Database=student; Password=needhelp; Integrated Security=true";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = String.Format("insert into students values ('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("Index");
            }
            return View(s);
        }

    }

}
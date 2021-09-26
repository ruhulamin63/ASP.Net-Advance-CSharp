using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture_3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please put your name")]
        [StringLength(10, ErrorMessage = "Name should not exceed 10 charcter")]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        public Double Cgpa { get; set; }
    }
}
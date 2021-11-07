using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class LoginUserModel
    {
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password length must be atleast 6")]
        public string password { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        public string user_type { get; set; }
        [Required]
        public string address { get; set; }
        public string status { get; set; }
        [Required]
        public string fullname { get; set; }
    }
}
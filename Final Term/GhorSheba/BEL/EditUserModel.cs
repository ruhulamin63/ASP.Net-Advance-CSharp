using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class EditUserModel
    {
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string usertype { get; set; }
        public string verification_status { get; set; }
        [Required]
        public string id_status { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

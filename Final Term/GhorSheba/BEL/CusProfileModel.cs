using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CusProfileModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string phone { get; set; }
        public string id_status { get; set; }
        public string usertype { get; set; }
        public string verification_status { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

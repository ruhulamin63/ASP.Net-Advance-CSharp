using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ServUserModel
    {
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string phone { get; set; }
        public string work_status { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> rating_count { get; set; }
        public Nullable<int> services_done { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string usertype { get; set; }
        public string verification_status { get; set; }
        [Required]
        public string id_status { get; set; }
    }
}

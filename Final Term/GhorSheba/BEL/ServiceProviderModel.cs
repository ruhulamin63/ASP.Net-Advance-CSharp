using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ServiceProviderModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string work_status { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> rating_count { get; set; }
        public Nullable<int> services_done { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

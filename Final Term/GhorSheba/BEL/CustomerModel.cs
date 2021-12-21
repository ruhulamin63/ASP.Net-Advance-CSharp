using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CustomerModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string phone { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}

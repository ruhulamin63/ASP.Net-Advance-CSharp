using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class EditServiceModel
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string category { get; set; }
        [Required]
        public int unit_price { get; set; }
        [Required]
        public int discount_amount { get; set; }
        [Required]
        public string description { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}

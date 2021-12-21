using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CouponModel
    {
        public int id { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public Nullable<int> amount { get; set; }
        [Required]
        public Nullable<int> min_order_amount { get; set; }
        [Required]
        public Nullable<int> max_use_number { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

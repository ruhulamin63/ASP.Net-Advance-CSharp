using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CustomerCouponModel
    {
        public int id { get; set; }
        public int booking_id { get; set; }
        public int customer_id { get; set; }
        public int coupon_id { get; set; }
        public int used_count { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}

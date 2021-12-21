using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class AdminBookingDetailModel
    {
        public int id { get; set; }
        public int booking_id { get; set; }
        public int service_id { get; set; }
        public int unit_price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BookingModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int total_cost { get; set; }
        public System.DateTime order_date { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string payment_status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Book_Bookingser
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public Nullable<int> total_cost { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string payment_status { get; set; }
        public int booking_id { get; set; }
        public int serviceprovider_id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public Nullable<int> total_cost { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public string status { get; set; }
    }
}

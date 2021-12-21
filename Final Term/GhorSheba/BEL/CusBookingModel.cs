using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CusBookingModel
    {
        public int id { get; set; }
        public int s_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int unit_price { get; set; }
        public int quantity { get; set; }
        public int total_cost { get; set; }
        public int user_id { get; set; }
    }
}

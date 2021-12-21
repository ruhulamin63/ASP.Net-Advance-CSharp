using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ServiceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public Nullable<int> unit_price { get; set; }
        public Nullable<int> discount_amount { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

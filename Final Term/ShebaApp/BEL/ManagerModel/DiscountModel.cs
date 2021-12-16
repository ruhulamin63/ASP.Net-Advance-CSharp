using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.ManagerModel
{
    public class DiscountModel
    {
        public int id { get; set; }
        public int service_id { get; set; }
        public int discount_percent { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

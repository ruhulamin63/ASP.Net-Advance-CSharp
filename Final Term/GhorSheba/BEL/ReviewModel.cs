using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.ManagerModel
{
    public class ReviewModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int serviceprovider_id { get; set; }
        public string description { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ServiceProviderBonusModel
    {
        public int id { get; set; }
        public int min_service_done { get; set; }
        public int bonus_amount { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }

        public int service_provider_id { get; set; }
        public int bonus_id { get; set; }

        public int user_id { get; set; }
        public string phone { get; set; }
        public string work_status { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> rating_count { get; set; }
        public Nullable<int> services_done { get; set; }
    }
}

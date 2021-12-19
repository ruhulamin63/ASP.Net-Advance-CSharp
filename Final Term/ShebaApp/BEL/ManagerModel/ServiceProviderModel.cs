using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ServiceProviderModel 
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string phone { get; set; }
        public string work_status { get; set; }
        public string rating { get; set; }
        public string services_done { get; set; }

        //public virtual UserModel User { get; set; }
    }
}

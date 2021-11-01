using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class ComplaintModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        public virtual LoginUser LoginUser { get; set; }
    }
}
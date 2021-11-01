using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class BookingModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int cost { get; set; }
        public string status { get; set; }
        public string payment_status { get; set; }
    }
}
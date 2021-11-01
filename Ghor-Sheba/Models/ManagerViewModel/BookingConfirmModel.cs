using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class BookingConfirmModel
    {
        public int id { get; set; }
        public int booking_id { get; set; }
        public int service_provider_id { get; set; }
        public string status { get; set; }
    }
}
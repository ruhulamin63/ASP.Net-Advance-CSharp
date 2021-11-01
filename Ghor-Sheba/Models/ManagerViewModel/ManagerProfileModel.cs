using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class ManagerProfileModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string user_type { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string fullname { get; set; }
        public byte[] image { get; set; }
    }
}
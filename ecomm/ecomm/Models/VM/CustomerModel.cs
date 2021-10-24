using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomm.Models.VM
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public string AccessLevel { get; internal set; }
    }
}
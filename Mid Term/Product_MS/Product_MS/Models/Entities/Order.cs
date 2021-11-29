using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_MS.Models.Entities
{
    public class Order
    {
        public string OrderId { get; set; }
        public List<Product> Products { get; set; }

    }
}
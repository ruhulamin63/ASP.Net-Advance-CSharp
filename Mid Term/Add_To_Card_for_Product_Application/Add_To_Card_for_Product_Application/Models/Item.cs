using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Add_To_Card_for_Product_Application.Models
{
    public class Item
    {
        public Product Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}
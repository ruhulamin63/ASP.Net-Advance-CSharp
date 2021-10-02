﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Add_To_Card_for_Product_Application.Models
{
    public class Item
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Price
        {
            get;
            set;
        }

        public string Photo
        {
            get;
            set;
        }

        public string Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        } 
        
        public int Total
        {
            get;
            set;
        }
    }
}
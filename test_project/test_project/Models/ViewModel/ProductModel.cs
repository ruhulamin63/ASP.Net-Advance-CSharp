﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_project.Models.ViewModel{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.Models.ManagerViewModel
{
    public class ServiceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public Nullable<int> cost { get; set; }
    }
}
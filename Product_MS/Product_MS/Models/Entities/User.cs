﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_MS.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
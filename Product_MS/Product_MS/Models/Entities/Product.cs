using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_MS.Models.Entities
{
    public class Product
    {
        [Required(ErrorMessage = "Please put your id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please put your name")]
        [StringLength(10, ErrorMessage = "Name should not exceed 10 charcter")]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
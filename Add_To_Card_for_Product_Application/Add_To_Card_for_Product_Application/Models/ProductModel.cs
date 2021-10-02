using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Add_To_Card_for_Product_Application.Models
{
    public class ProductModel
    {
        private List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>() {
                new Product {
                    Id = "01",
                    Name = "Diamond Cart",
                    Price = 5,
                    Photo = "thumb1.gif"
                },
                new Product {
                    Id = "02",
                    Name = "Welcome Cart",
                    Price = 2,
                    Photo = "thumb2.gif"
                },
                new Product {
                    Id = "03",
                    Name = "Bike Cart",
                    Price = 6,
                    Photo = "thumb3.gif"
                }
            };
        }

        public List<Product> findAll()
        {
            return this.products;
        }

        public Product find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }


    }
}
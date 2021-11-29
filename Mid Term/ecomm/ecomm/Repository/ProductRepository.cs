using ecomm.Models.VM;
using ecomm.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomm.Repository
{
    public class ProductRepository
    {
        static e_commerce_siteEntities db;

        static ProductRepository()
        {
            db = new e_commerce_siteEntities();
        }

        public static ProductModel Get(int Id)
        {
            var p = (from pr in db.products
                     where pr.id == Id
                     select pr).FirstOrDefault();

            return new ProductModel()
            {
                id = p.id,
                name = p.name,
                price = p.price
            };
        }

        public static List<ProductModel> GetAll()
        {
            var product = new List<ProductModel>();

            foreach (var p in db.products)
            {
                ProductModel pm = new ProductModel()
                {
                    id = p.id,
                    name = p.name,
                    price = p.price
                };
                product.Add(pm);
            }
            return product;
        }
    }
}
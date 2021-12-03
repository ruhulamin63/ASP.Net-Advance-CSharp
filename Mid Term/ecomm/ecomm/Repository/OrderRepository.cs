using ecomm.Models.EF;
using ecomm.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomm.Repository
{
    public class OrderRepository
    {
        static e_commerce_siteEntities db;

        static OrderRepository()
        {
            db = new e_commerce_siteEntities();
        }

        public static void PlaceOrder(List<ProductModel> products, int cId)
        {
            order o = new order();

            o.customer_id = cId;
            o.status = "Orderd";

            db.orders.Add(o);
            db.SaveChanges();

            foreach (var p in products)
            {
                var od = new order_details()
                {
                    product_id = p.id,
                    unit_price = p.price,
                    qty = 1,
                    order_id = o.id
                };
                db.order_details.Add(od);
                db.SaveChanges();
            }
        }

        public static List<order> MyOrders(int id)
        {
            //return db.orders.Where(e => e.id == id).ToList();

            var orders = (from e in db.orders
                         where e.customer_id == id
                         select e);

            return orders.ToList();
        }
    }
}
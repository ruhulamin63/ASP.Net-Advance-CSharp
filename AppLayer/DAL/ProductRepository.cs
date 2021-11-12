using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository
    {
        static ProductEntities db;

        static ProductRepository()
        {
            db = new ProductEntities();
        }

        public static List<product> GetAll()
        {
            return db.products.ToList();
        }

        public static product Get(int id)
        {
            return db.products.FirstOrDefault(e => e.Id == id);
        }

        public static void Edit(product p)
        {
            var pro = db.products.FirstOrDefault(e=>e.Id == p.Id);
            db.Entry(pro).CurrentValues.SetValues(pro);
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            var pro = db.products.FirstOrDefault(e => e.Id == id);
            db.products.Remove(pro);
            db.SaveChanges();
        }
    }
}

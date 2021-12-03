using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository : IRepository<product, int>
    {
        ProductEntities db;

        public ProductRepository(ProductEntities db)
        {
            this.db = db;
        }

        public void Add(product e)
        {
            db.products.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.products.FirstOrDefault(en => en.Id == id);
            db.products.Remove(e);
            db.SaveChanges();
        }

        public void Edit(product e)
        {
            var p = db.products.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<product> Get()
        {
            return db.products.ToList();
        }

        public product Get(int id)
        {
            return db.products.FirstOrDefault(e => e.Id == id);
        }
    }
}

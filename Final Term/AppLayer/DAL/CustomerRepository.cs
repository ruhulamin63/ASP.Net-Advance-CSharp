using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CustomerRepository : IRepository<customer, int>
    {
        ProductEntities db;

        public CustomerRepository(ProductEntities db)
        {
            this.db = db;
        }

        public void Add(customer e)
        {
            db.customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = db.customers.FirstOrDefault(e => e.Id == id);
            db.customers.Remove(c);
            db.SaveChanges();
        }

        public void Edit(customer e)
        {
            var c = db.customers.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(c).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<customer> Get()
        {
            return db.customers.ToList();
        }

        public customer Get(int id)
        {
            return db.customers.FirstOrDefault(e => e.Id == id);
        }
    }
}

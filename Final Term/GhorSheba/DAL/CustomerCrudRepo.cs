using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerCrudRepo : AdminIRepository<Customer, int>
    {
        ShebaDbEntities db;
        public CustomerCrudRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Customer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Customers.FirstOrDefault(en => en.user_id == id);
            db.Customers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Customer e)
        {
            var p = db.Customers.FirstOrDefault(en => en.user_id == e.user_id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(e => e.user_id == id);
        }
    }
}

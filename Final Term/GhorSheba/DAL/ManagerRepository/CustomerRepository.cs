using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class CustomerRepository : ManagerInterface<Customer, int>
    {
        ShebaDbEntities db;

        public CustomerRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Customer e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer e)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

       /* public List<Booking> GetByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDate(DateTime order_date)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDateCustomerId(DateTime order_date, int id)
        {
            throw new NotImplementedException();
        }*/

        public Customer AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}

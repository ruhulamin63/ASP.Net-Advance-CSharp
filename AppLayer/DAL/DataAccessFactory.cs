using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static ProductEntities db;

        static DataAccessFactory()
        {
            db = new ProductEntities();
        }

        public static IRepository<product, int> ProductDataAccess()
        {
            return new ProductRepository(db);
        }

        public static IRepository<customer, int> CustomerDataAccess()
        {
            return new CustomerRepository(db);
        }
    }
}

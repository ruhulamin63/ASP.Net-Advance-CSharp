using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ServiceProviderRepository : IRepository<ServiceProvider, int>
    {
        ShebaDbEntities db;

        public ServiceProviderRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(ServiceProvider e)
        {
            db.ServiceProviders.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(ServiceProvider e)
        {
            var p = db.ServiceProviders.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.ServiceProviders.FirstOrDefault(en => en.id == id);
            db.ServiceProviders.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public List<ServiceProvider> Get()
        {
            return db.ServiceProviders.ToList();
        }

        public ServiceProvider Get(int id)
        {
            return db.ServiceProviders.FirstOrDefault(e => e.id == id);
        }

        //=================================================================

        public List<Booking> GetByCustomerId(int id)
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
        }
    }
}

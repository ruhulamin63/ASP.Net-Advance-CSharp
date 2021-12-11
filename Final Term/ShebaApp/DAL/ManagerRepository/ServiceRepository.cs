using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ServiceRepository : IRepository<Service, int>
    {
        ShebaDbEntities db;

        public ServiceRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Service e)
        {
            db.Services.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Service e)
        {
            var p = db.Services.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Services.FirstOrDefault(en => en.id == id);
            db.Services.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public List<Service> Get()
        {
            return db.Services.ToList();
        }

        public Service Get(int id)
        {
            return db.Services.FirstOrDefault(e => e.id == id);
        }

        //======================================================================

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

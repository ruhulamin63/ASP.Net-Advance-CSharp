using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingServiceRepository : IRepository<Booking_Service, int>
    {
        ShebaDbEntities db;

        public BookingServiceRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Booking_Service e)
        {
            db.Booking_Service.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Booking_Service.FirstOrDefault(en => en.id == id);
            db.Booking_Service.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Booking_Service e)
        {
            var p = db.Booking_Service.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<Booking_Service> Get()
        {
            return db.Booking_Service.ToList();
        }

        public Booking_Service Get(int id)
        {
            return db.Booking_Service.FirstOrDefault(e => e.id == id);
        }

        public List<Booking> GetByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDateCustomerId(DateTime dateTime, int c_id)
        {
            throw new NotImplementedException();
        }
    }
}

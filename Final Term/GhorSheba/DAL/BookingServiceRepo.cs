using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingServiceRepo : AdminIRepository<Booking_Service, int>
    {
        ShebaDbEntities db;
        public BookingServiceRepo(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Booking_Service e)
        {
            db.Booking_Service.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Booking_Service.FirstOrDefault(en => en.serviceprovider_id == id);
            db.Booking_Service.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Booking_Service e)
        {
            throw new NotImplementedException();
        }

        public List<Booking_Service> Get()
        {
            return db.Booking_Service.ToList();
        }

        public Booking_Service Get(int id)
        {
            return db.Booking_Service.FirstOrDefault(e => e.serviceprovider_id == id);
        }
    }
}

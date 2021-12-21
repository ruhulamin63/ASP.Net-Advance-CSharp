using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SerBooking_ServiceRepo : ServiceProviderIRepository<Booking_Service, int>
    {
        ShebaDbEntities db;
        public SerBooking_ServiceRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Booking_Service e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Booking_Service e)
        {
            var p = db.Booking_Service.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Booking_Service> Get()
        {
            return db.Booking_Service.ToList();
        }

        public Booking_Service Get(int id)
        {
            return db.Booking_Service.FirstOrDefault(e => e.id == id);
        }
    }
}

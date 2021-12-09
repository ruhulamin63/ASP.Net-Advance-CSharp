using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingRepository : IRepository<Booking, int>
    {
        ShebaDbEntities db;

        public BookingRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Booking e)
        {
            db.Bookings.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Bookings.FirstOrDefault(en => en.id == id);
            db.Bookings.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Booking e)
        {
            var p = db.Bookings.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<Booking> Get()
        {
            return db.Bookings.ToList();
        }

        public Booking Get(int id)
        {
            return db.Bookings.FirstOrDefault(e => e.id == id);
        }
    }
}

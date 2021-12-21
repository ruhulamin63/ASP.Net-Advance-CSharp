using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingRepo : AdminIRepository<Booking, int>
    {
        ShebaDbEntities db;
        public BookingRepo(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Booking e)
        {
            db.Bookings.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Bookings.FirstOrDefault(en => en.customer_id == id);
            db.Bookings.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Booking e)
        {
            var p = db.Bookings.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
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

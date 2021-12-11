using BEL;
using DAL.Interface_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDetailsRepository : BookingDetailsInterface<Booking_Details, int>
    {

        ShebaDbEntities db;

        public BookingDetailsRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Booking_Details e)
        {
            db.Booking_Details.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Booking_Details.FirstOrDefault(en => en.id == id);
            db.Booking_Details.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Booking_Details e)
        {
            var p = db.Booking_Details.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<Booking_Details> Get()
        {
            return db.Booking_Details.ToList();
        }

        public Booking_Details Get(int id)
        {
            return db.Booking_Details.FirstOrDefault(e => e.id == id);
        }
    }
}

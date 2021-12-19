using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDetailsRepository : ManagerInterface<Booking_Details, int>
    {

        ShebaDbEntities db;

        public BookingDetailsRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Booking_Details e)
        {
            db.Booking_Details.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Booking_Details.FirstOrDefault(en => en.id == id);
            db.Booking_Details.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Booking_Details e)
        {
            var p = db.Booking_Details.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Booking_Details> Get()
        {
            return db.Booking_Details.ToList();
        }

        public Booking_Details Get(int id)
        {
            return db.Booking_Details.FirstOrDefault(e => e.id == id);
        }

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
        public Booking_Details AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}

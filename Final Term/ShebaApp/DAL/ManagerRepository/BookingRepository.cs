using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingRepository : ManagerRepository<Booking, int>
    {
        ShebaDbEntities db;

        public BookingRepository(ShebaDbEntities db)
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
            var e = db.Bookings.FirstOrDefault(en => en.id == id);
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

        public List<Booking> GetByCustomerId(int id)
        {
            var e = (from books in db.Bookings where books.customer_id == id select books).ToList();
            return e;
        }

        public List<Booking> GetByOrderDate(DateTime order_date)
        {
            var e = (from books in db.Bookings where books.order_date == order_date select books).ToList();
            return e;
        }

        public List<Booking> GetByOrderDateCustomerId(DateTime order_date, int c_id)
        {
            var e = (from books in db.Bookings where books.order_date == order_date && books.customer_id == c_id select books).ToList();
            return e;
        }
    }
}

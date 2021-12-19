using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingRepository : ManagerInterface<Booking, int>
    {
        ShebaDbEntities db;

        public BookingRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Booking e)
        {
            
            Booking user = new Booking()
            {
                customer_id = e.customer_id,
                total_cost = e.total_cost,
                order_date = DateTime.Now,
                status = e.status,
                payment_status = e.payment_status,
                created_at = DateTime.Now,
            };
            db.Bookings.Add(user);
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
            Booking user = new Booking()
            {
                customer_id = e.customer_id,
                total_cost = e.total_cost,
                order_date = DateTime.Now,
                status = e.status,
                payment_status = e.payment_status,
                updated_at = DateTime.Now,
            };
            db.Entry(user).CurrentValues.SetValues(p);
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

        public Booking AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}

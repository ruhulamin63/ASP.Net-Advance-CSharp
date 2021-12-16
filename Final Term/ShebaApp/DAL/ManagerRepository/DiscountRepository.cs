using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class DiscountRepository : Salary_Interface<Discount, int>
    {
        ShebaDbEntities db;

        public DiscountRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Discount e, int id)
        {
            var data = db.Discounts.FirstOrDefault(en => en.service_id == id);

            Discount t = null;

            if (t == null)
            {
                t = new Discount()
                {
                    service_id = id,
                    discount_percent = 20,
                    created_at = DateTime.Now
                };
                db.Discounts.Add(t);
            }

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Discounts.FirstOrDefault(en => en.id == id);
            db.Discounts.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Discount e)
        {
            var p = db.Discounts.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Discount> Get()
        {
            return db.Discounts.ToList();
        }

        public Discount Get(int id)
        {
            return db.Discounts.FirstOrDefault(e => e.id == id);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class CouponRepository : ManagerInterface<Coupon, int>
    {
        ShebaDbEntities db;

        public CouponRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Coupon e)
        {
            db.Coupons.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Coupons.FirstOrDefault(en => en.id == id);
            db.Coupons.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Coupon e)
        {
            var p = db.Coupons.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Coupon> Get()
        {
            return db.Coupons.ToList();
        }

        public Coupon Get(int id)
        {
            return db.Coupons.FirstOrDefault(e => e.id == id);
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
        public Coupon AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}

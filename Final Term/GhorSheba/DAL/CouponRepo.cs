using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CouponRepo : AdminIRepository<Coupon, int>
    {
        ShebaDbEntities db;
        public CouponRepo(ShebaDbEntities db)
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
    }
}

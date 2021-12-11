using DAL.Interface_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class CouponRepository : CouponInterface<Coupon, int>
    {
        ShebaDbEntities db;

        public CouponRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Coupon e)
        {
            db.Coupons.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Coupons.FirstOrDefault(en => en.id == id);
            db.Coupons.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Coupon e)
        {
            var p = db.Coupons.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
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

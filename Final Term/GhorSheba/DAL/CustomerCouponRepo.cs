using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerCouponRepo : AdminIRepository<Customer_Coupon, int>
    {
        ShebaDbEntities db;
        public CustomerCouponRepo(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Customer_Coupon e)
        {
            db.Customer_Coupon.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Customer_Coupon.FirstOrDefault(en => en.customer_id == id);
            db.Customer_Coupon.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Customer_Coupon e)
        {
            throw new NotImplementedException();
        }

        public List<Customer_Coupon> Get()
        {
            return db.Customer_Coupon.ToList();
        }

        public Customer_Coupon Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

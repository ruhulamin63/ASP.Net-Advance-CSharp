using AutoMapper;
using BEL;
using BEL.ManagerModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ManagerServices
{
    public class CouponService
    {
        //******************************************* Coupon CRUD starts *******************************//

        public static List<CouponModel> GetCoupons()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponModel>>(DataAccessFactory.CouponDataAccess().Get());
            return data;
        }

        public static CouponModel GetCoupon(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponModel>(DataAccessFactory.CouponDataAccess().Get(id));
            return data;
        }

        public static void EditCoupon(CouponModel c)
        {
            var coupon = DataAccessFactory.CouponDataAccess().Get(c.id);
            coupon.amount = c.amount;
            coupon.max_use_number = c.max_use_number;
            coupon.min_order_amount = c.min_order_amount;
            coupon.status = c.status;
            coupon.updated_at = c.updated_at;
            DataAccessFactory.CouponDataAccess().Edit(coupon);
        }

        public static void AddCoupon(CouponModel c)
        {
            var coupon = new Coupon();
            coupon.amount = c.amount;
            coupon.max_use_number = c.max_use_number;
            coupon.min_order_amount = c.min_order_amount;
            coupon.status = c.status;
            coupon.created_at = DateTime.Now;
            coupon.updated_at = DateTime.Now;

            DataAccessFactory.CouponDataAccess().Add(coupon);
        }
        public static int DeleteCoupon(int id)
        {
            try
            {
                DataAccessFactory.CouponDataAccess().Delete(id);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //******************************************* Coupon CRUD ends *******************************//
    }
}

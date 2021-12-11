using AutoMapper;
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
        public static List<CouponModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, CouponModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponModel>>(DataAccessFactory.CouponServiceDataAccess().Get());
            return data;
        }

        public static CouponModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, CouponModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponModel>(DataAccessFactory.CouponServiceDataAccess().Get(id));
            return data;
        }

        public static bool Add(CouponModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponModel, Coupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(n);
            return DataAccessFactory.CouponServiceDataAccess().Add(data);
        }

        public static bool Edit(CouponModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponModel, Coupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(n);
            return DataAccessFactory.CouponServiceDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CouponServiceDataAccess().Delete(id);
        }
    }
}

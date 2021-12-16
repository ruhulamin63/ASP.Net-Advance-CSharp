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
            var data = mapper.Map<List<CouponModel>>(ManagerDataAccessFactory.CouponServiceDataAccess().Get());
            return data;
        }

        public static CouponModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, CouponModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponModel>(ManagerDataAccessFactory.CouponServiceDataAccess().Get(id));
            return data;
        }

        public static void Add(CouponModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponModel, Coupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(n);
            ManagerDataAccessFactory.CouponServiceDataAccess().Add(data);
        }

        public static void Edit(CouponModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponModel, Coupon>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(n);
            ManagerDataAccessFactory.CouponServiceDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.CouponServiceDataAccess().Delete(id);
        }
    }
}

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
    public class DiscountService
    {
        public static List<DiscountModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<DiscountModel>>(ManagerDataAccessFactory.DiscountDataAccess().Get());
            return data;
        }

        public static DiscountModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DiscountModel>(ManagerDataAccessFactory.DiscountDataAccess().Get(id));
            return data;
        }

        public static void Add(DiscountModel n, int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<DiscountModel, Discount>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Discount>(n);
            ManagerDataAccessFactory.DiscountDataAccess().Add(data,id);
        }

        public static void Edit(DiscountModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<DiscountModel, Discount>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Discount>(n);
            ManagerDataAccessFactory.DiscountDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.DiscountDataAccess().Delete(id);
        }
    }
}

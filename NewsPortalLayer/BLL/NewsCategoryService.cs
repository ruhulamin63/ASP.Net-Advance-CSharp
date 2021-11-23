using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class NewsCategoryService
    {
        /*public static List<NewsCategoryModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News_category, NewsCategoryModel>());
            var mapper = new Mapper(config);
            *//*var data = mapper.Map<List<CustomerModel>>(CustomerRepository.GetAll());*//*
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.NewsCategoryDataAccess().Get());

            return data;
        }*/

        public static List<NewsCategoryModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News_category, NewsCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.NewsCategoryDataAccess().Get());
            return data;
        }

        public static NewsCategoryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News_category, NewsCategoryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsCategoryModel>(DataAccessFactory.NewsCategoryDataAccess().Get(id));
            return data;
        }

        public static bool Add(NewsCategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsCategoryModel, News_category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News_category>(n);
            return DataAccessFactory.NewsCategoryDataAccess().Add(data);
        }

        public static bool Edit(NewsCategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsCategoryModel, News_category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News_category>(n);
            return DataAccessFactory.NewsCategoryDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsCategoryDataAccess().Delete(id);
        }

        public static List<string> GetNames()
        {
            /*var data = (from e in NewsCategoryRepository.GetAll()
                        select e.name).ToList();
            var data = NewsCategoryRepository.GetAll().Select(e => e.name).ToList();*/

            var data = DataAccessFactory.NewsCategoryDataAccess().Get().Select(e => e.name).ToList();

            return data;
        }
    }
}

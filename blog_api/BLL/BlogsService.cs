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
    public class BlogsService
    {
        //auto mapper 6.1.1 used
        public static List<BlogModel> Get() {
            //AutoMapper.Mapper
            //Mapper.Initialize(cfg => cfg.CreateMap<Blog, BlogModel>());
            // var data = AutoMapper.Mapper.Map<List<BlogModel>>(DataAccessFactory.BlogsDataAccess().Get()); // for automapper 6.1.1

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BlogModel>>(DataAccessFactory.BlogsDataAccess().Get());

            return data;
        }
        public static BlogModel Get(int id) {
            
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BlogModel>(DataAccessFactory.BlogsDataAccess().Get(id));

            return data;
        }
        public static bool Create(BlogModel blog)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BlogModel, Blog>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Blog>(blog);

            return DataAccessFactory.BlogsDataAccess().Add(data);

        }
        public static bool Edit(BlogModel blog)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BlogModel, Blog>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Blog>(blog);

            return DataAccessFactory.BlogsDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BlogsDataAccess().Delete(id);
        }




    }
}

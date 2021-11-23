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
    public class NewsService
    {
        /*public static List<NewsModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);

            *//*var data = mapper.Map<List<ProductModel>>(ProductRepository.GetAll());*/
            /*IRepository<product, int> repo = DataAccessFactory.ProductDataAccess();*//*

            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.ProductDataAccess().Get());

            return data;
        }*/

        public static List<NewsCategoryModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.NewsDataAceess().Get());
            return data;
        }

        public static NewsModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsModel>(DataAccessFactory.NewsDataAceess().Get(id));
            return data;
        }

        public static bool Add(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return DataAccessFactory.NewsDataAceess().Add(data);
        }

        public static bool Edit(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return DataAccessFactory.NewsDataAceess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsDataAceess().Delete(id);
        }

       /* public static List<string> GetNames()
        {
            *//*var data = (from e in NewsCategoryRepository.GetAll()
                        select e.name).ToList();
            var data = NewsCategoryRepository.GetAll().Select(e => e.name).ToList();*//*

            var data = DataAccessFactory.NewsDataAceess().Get().Select(e => e.name).ToList();

            return data;
        }*/
    }
}

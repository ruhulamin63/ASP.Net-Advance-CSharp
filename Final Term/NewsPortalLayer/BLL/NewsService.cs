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

        public static List<NewsModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
        }

        public static NewsModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsModel>(DataAccessFactory.NewsDataAccess().Get(id));
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
            return DataAccessFactory.NewsDataAccess().Add(data);
        }

        public static bool Edit(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return DataAccessFactory.NewsDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsDataAccess().Delete(id);
        }

        public static List<NewsModel> GetByDate(DateTime dateTime)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Comment, CommentModel>();
                c.CreateMap<React, ReactModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByDate(dateTime));
            return data;
        }
        public static List<NewsModel> GetByCategory(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>().ReverseMap();
                c.CreateMap<Comment, CommentModel>();
                c.CreateMap<React, ReactModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByCategory(id));
            return data;
        }
        public static List<NewsModel> GetByDateCategory(DateTime dateTime, string category)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Comment, CommentModel>();
                c.CreateMap<React, ReactModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByDateCategory(dateTime, category));
            return data;
        }
    }
}

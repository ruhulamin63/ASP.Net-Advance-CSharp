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
    public class ReviewService
    {
        public static List<ReviewModel> GetAll() //GetAll(string uty
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ReviewModel>>(ManagerDataAccessFactory.ReviewDataAccess().Get());

            /* var manager = new List<UserModel>();

           foreach (var a in data)
           {
               if (a.usertype == utype)
               {
                   manager.Add(a);
               }
           }
           return manager; */

            return data;
        }

        public static ReviewModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ReviewModel>(ManagerDataAccessFactory.ReviewDataAccess().Get(id));
            return data;
        }
    }
}

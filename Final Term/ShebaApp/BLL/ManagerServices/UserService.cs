using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using BEL.ManagerModel;

namespace BLL
{
    public class UserService
    {
        public static List<UserModel> GetAll() //GetAll(string uty
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>().ReverseMap();
                c.CreateMap<ServiceProvider, ServiceProviderModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(ManagerDataAccessFactory.UserDataAccess().Get());

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

        public static UserModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(ManagerDataAccessFactory.UserDataAccess().Get(id));
            return data;
        }

        public static void Add(UserModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(n);
            ManagerDataAccessFactory.UserDataAccess().Add(data);
        }

        public static void Edit(UserModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(n);
            ManagerDataAccessFactory.UserDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.UserDataAccess().Delete(id);
        }
    }
}

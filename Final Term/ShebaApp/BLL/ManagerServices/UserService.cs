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
    public class UserService
    {
        public static List<UserModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());
            return data;
        }

        public static UserModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }

        public static bool Add(UserModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(n);
            return DataAccessFactory.UserDataAccess().Add(data);
        }

        public static bool Edit(UserModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(n);
            return DataAccessFactory.UserDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }
    }
}

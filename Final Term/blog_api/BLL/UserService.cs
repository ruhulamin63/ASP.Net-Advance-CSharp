using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;

namespace BLL
{
    public class UserService
    {
        static UserService() {
           /* Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });*/

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
        }
        public static List<UserModel> Get()
        {
            //AutoMapper.Mapper
            /*var data = AutoMapper.Mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get()); // for automapper 6.1.1
            return data;*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            return data;
        }
        public static UserModel Get(int id)
        {

            /*var data = Mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id)); // for automapper 6.1.1
            return data;*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(DataAccessFactory.BlogsDataAccess().Get(id));

            return data;
        }
        public static bool Create(UserModel user)
        {

            /*var data = Mapper.Map<User>(user); // for automapper 6.1.1
            DataAccessFactory.UserDataAccess().Add(data);*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);

            return DataAccessFactory.UserDataAccess().Add(data);

        }
        public static bool Edit(UserModel user)
        {
            /*Mapper.Initialize(cfg => cfg.CreateMap<UserModel, Token>());
            var data = Mapper.Map<User>(user); // for automapper 6.1.1
            DataAccessFactory.UserDataAccess().Edit(data);*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);

            return DataAccessFactory.UserDataAccess().Edit(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }


    }
}

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
    public class AuthService
    {
       /* static AuthService()
        {
            *//* Mapper.Initialize(cfg => {
                 cfg.CreateMap<User, UserModel>();
                 cfg.CreateMap<UserModel, User>();
             });*//* //6.1.1 version

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
        }*/

        public static TokenModel Auth(UserModel user)
        {
            //convert user model to user then send to auth repository
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserModel, User>();
                c.CreateMap<UserModel, User>();
                c.CreateMap<Token, TokenModel>();
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            var token = DataAccessFactory.AuthDataAccess().Authenticate(data);

            var tokenModel = mapper.Map<TokenModel>(token);

            return tokenModel;
        }
    }
}

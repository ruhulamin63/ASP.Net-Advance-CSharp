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
        public static TokenModel Auth(UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            var token = AuthDataAccessFactory.AuthDataAccess().Authenticate(data);

            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenModel>());
            var mapper1 = new Mapper(config1);
            var data1 = mapper1.Map<TokenModel>(token);
            return data1;
        }
        public static bool CheckValidityToken(string token)
        {
            var rs = AuthDataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }

        public static UserModel GetUserType(int id)
        {
            var u = AuthDataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(u);
            return data;
        }

        public static void DeleteToken(int id)
        {
           
            while(true)
            {
                var t = DataAccessFactory.TokenDataAccess().Get(id);
                if(t==null)
                {
                    break;
                }
                DataAccessFactory.TokenDataAccess().Delete(t.user_id);
            }
        }
    }
}

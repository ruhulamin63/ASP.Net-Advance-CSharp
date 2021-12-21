using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TokenService
    {
        //auto mapper 6.1.1 used
        public static List<TokenModel> Get()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<TokenModel>>(AuthDataAccessFactory.TokenDataAccess().Get());
           
            return data;
        }
        public static TokenModel Get(string token)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenModel>());
            var mapper = new Mapper(config);
            var data =mapper.Map<TokenModel>(AuthDataAccessFactory.TokenDataAccess().Get(token)); // for automapper 6.1.1
            return data;
        }
        public static void Create(TokenModel token)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TokenModel, Token>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Add(data);

        }
        public static void Edit(TokenModel token)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TokenModel, Token>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Edit(data);

        }
        public static void Delete(string token)
        {
            AuthDataAccessFactory.TokenDataAccess().Delete(token);
        }

    }
}

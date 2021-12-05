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
    public class TokenService
    {
        //auto mapper 6.1.1 used
        public static List<TokenModel> Get()
        {
            //AutoMapper.Mapper
            /* Mapper.Initialize(cfg => cfg.CreateMap<Token, TokenModel>());
             var data = AutoMapper.Mapper.Map<List<TokenModel>>(DataAccessFactory.TokenDataAccess().Get()); // for automapper 6.1.1
             return data;*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<TokenModel>>(DataAccessFactory.TokenDataAccess().Get());

            return data;
        }
        public static TokenModel Get(string token)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<TokenModel>(DataAccessFactory.TokenDataAccess().Get(token));

            return data;
        }
        public static bool Create(TokenModel token)
        {
            /*Mapper.Initialize(cfg => cfg.CreateMap<TokenModel, Token>());
            var data = Mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Add(data);*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(token);

            return DataAccessFactory.TokenDataAccess().Add(data);
        }
        public static bool Edit(TokenModel token)
        {
            /*Mapper.Initialize(cfg => cfg.CreateMap<TokenModel, Token>());
            var data = Mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Edit(data);*/

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TokenModel, Token>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Token>(token);

            return DataAccessFactory.TokenDataAccess().Edit(data);
        }
        public static bool Delete(string token)
        {
            return DataAccessFactory.TokenDataAccess().Delete(token);
        }
    }
}

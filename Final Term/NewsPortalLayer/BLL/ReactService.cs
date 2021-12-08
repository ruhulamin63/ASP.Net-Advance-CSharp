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
    public class ReactService
    {
        public static List<ReactModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<React, ReactModel>());
            var mapper = new Mapper(config);
            /*var data = mapper.Map<List<CustomerModel>>(CustomerRepository.GetAll());*/
            var data = mapper.Map<List<ReactModel>>(DataAccessFactory.ReactDataAccess().Get());

            return data;
        }
    }
}

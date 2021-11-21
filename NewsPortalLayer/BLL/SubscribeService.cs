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
    public class SubscribeService
    {
        public static List<SubscriberModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Subscriber, SubscriberModel>());
            var mapper = new Mapper(config);
            /*var data = mapper.Map<List<CustomerModel>>(CustomerRepository.GetAll());*/
            var data = mapper.Map<List<SubscriberModel>>(DataAccessFactory.SubscriberDataAccess().Get());

            return data;
        }
    }
}

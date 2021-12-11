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
    public class ServiceToService
    {
        public static List<ServiceModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceModel>>(DataAccessFactory.ServicerToServiceDataAccess().Get());
            return data;
        }

        public static ServiceModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Service, ServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceModel>(DataAccessFactory.ServicerToServiceDataAccess().Get(id));
            return data;
        }

        public static bool Add(ServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceModel, Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(n);
            return DataAccessFactory.ServicerToServiceDataAccess().Add(data);
        }

        public static bool Edit(ServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceModel, Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Service>(n);
            return DataAccessFactory.ServicerToServiceDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ServicerToServiceDataAccess().Delete(id);
        }
    }
}

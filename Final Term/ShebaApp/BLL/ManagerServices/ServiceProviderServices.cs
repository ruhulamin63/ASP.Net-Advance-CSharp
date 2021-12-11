using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ManagerServices
{
    public class ServiceProviderServices
    {
        public static List<ServiceProviderModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceProviderModel>>(DataAccessFactory.SrviceProviderServiceDataAccess().Get());
            return data;
        }

        public static ServiceProviderModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProviderModel>(DataAccessFactory.SrviceProviderServiceDataAccess().Get(id));
            return data;
        }

        public static bool Add(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            return DataAccessFactory.SrviceProviderServiceDataAccess().Add(data);
        }

        public static bool Edit(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            return DataAccessFactory.SrviceProviderServiceDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SrviceProviderServiceDataAccess().Delete(id);
        }
    }
}

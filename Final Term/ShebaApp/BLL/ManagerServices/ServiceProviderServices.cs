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
            var data = mapper.Map<List<ServiceProviderModel>>(ManagerDataAccessFactory.SrviceProviderServiceDataAccess().Get());
            return data;
        }

        public static ServiceProviderModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProviderModel>(ManagerDataAccessFactory.SrviceProviderServiceDataAccess().Get(id));
            return data;
        }

        public static void Add(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            ManagerDataAccessFactory.SrviceProviderServiceDataAccess().Add(data);
        }

        public static void Edit(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            ManagerDataAccessFactory.SrviceProviderServiceDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.SrviceProviderServiceDataAccess().Delete(id);
        }
    }
}

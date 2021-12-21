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
            var data = mapper.Map<List<ServiceProviderModel>>(ManagerDataAccessFactory.ServiceProviderDataAccess().Get());
            return data;
        }

        public static ServiceProviderModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProviderModel>(ManagerDataAccessFactory.ServiceProviderDataAccess().Get(id));
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
            ManagerDataAccessFactory.ServiceProviderDataAccess().Add(data);
        }

        public static void Edit(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            ManagerDataAccessFactory.ServiceProviderDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.ServiceProviderDataAccess().Delete(id);
        }
        public static List<ServiceProviderModel> ConfirmBookedService(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceProviderModel>>(ManagerDataAccessFactory.ServiceProviderDataAccess().ConfirmBookedService(id));
            return data;
        }

        public static List<BookingServiceModel> AssignServices(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingService, BookingServiceModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingServiceModel>>(ManagerDataAccessFactory.BookingServiceDataAccess().AssignServices(id));
            return data;
        }
    }
}

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
    public class ServiceProviderServicesManager
    {
        public static List<ServiceProviderModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceProviderModel>>(ManagerDataAccessFactory.ServiceProviderDataAccess().GetSP());
            return data;
        }

        public static ServiceProviderModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProvider, ServiceProviderModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProviderModel>(ManagerDataAccessFactory.ServiceProviderDataAccess().GetSP(id));
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
            ManagerDataAccessFactory.ServiceProviderDataAccess().AddSP(data);
        }

        public static void Edit(ServiceProviderModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ServiceProviderModel, ServiceProvider>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ServiceProvider>(n);
            ManagerDataAccessFactory.ServiceProviderDataAccess().EditSP(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.ServiceProviderDataAccess().DeleteSP(id);
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

        /* public static List<BookingServiceModel> AssignServices(int id)
         {
             var config = new MapperConfiguration(c =>
             {
                 c.CreateMap<BookingService, BookingServiceModel>().ReverseMap();
             });
             var mapper = new Mapper(config);
             var data = mapper.Map<List<BookingServiceModel>>(ManagerDataAccessFactory.BookingServiceDataAccess().AssignServices(id));
             return data;
         }*/

        public static void AssignServices(BookingServiceModel s)
        {

            var booking = DataAccessFactory.BookingDataAccess().Get(s.booking_id);

            booking.status = "confirmed";
            booking.payment_status = "pending";
            booking.updated_at = DateTime.Now;
            DataAccessFactory.BookingDataAccess().Edit(booking);

            var sp = DataAccessFactory.ServiceProviderDataAccess().Get(s.serviceprovider_id);
            sp.work_status = "busy";
            DataAccessFactory.ServiceProviderDataAccess().Edit(sp);

            var bs = new Booking_Service();
            bs.serviceprovider_id = s.serviceprovider_id;
            bs.booking_id = s.booking_id;
            DataAccessFactory.BookingServiceDataAccess().Add(bs);
        }
    }
}

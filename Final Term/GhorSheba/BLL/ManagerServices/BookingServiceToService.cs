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
    public class BookingServiceToService
    {
        public static List<BookingServiceModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Service, BookingServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingServiceModel>>(ManagerDataAccessFactory.BookingServiceDataAccess().Get());
            return data;
        }

        public static BookingServiceModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Service, BookingServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingServiceModel>(ManagerDataAccessFactory.BookingServiceDataAccess().Get(id));
            return data;
        }

        public static void Add(BookingServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingServiceModel, Booking_Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Service>(n);
            ManagerDataAccessFactory.BookingServiceDataAccess().Add(data);
        }

        public static void Edit(BookingServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingServiceModel, Booking_Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Service>(n);
            ManagerDataAccessFactory.BookingServiceDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.BookingServiceDataAccess().Delete(id);
        }
    }
}

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
    public class BookingServiceTable
    {
        public static List<BookingServiceModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Service, BookingServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingServiceModel>>(DataAccessFactory.BookingServiceDataAccess().Get());
            return data;
        }

        public static BookingServiceModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Service, BookingServiceModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingServiceModel>(DataAccessFactory.BookingServiceDataAccess().Get(id));
            return data;
        }

        public static bool Add(BookingServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingServiceModel, Booking_Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Service>(n);
            return DataAccessFactory.BookingServiceDataAccess().Add(data);
        }

        public static bool Edit(BookingServiceModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingServiceModel, Booking_Service>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Service>(n);
            return DataAccessFactory.BookingServiceDataAccess().Edit(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BookingServiceDataAccess().Delete(id);
        }
    }
}

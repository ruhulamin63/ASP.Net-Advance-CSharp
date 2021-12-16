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
    public class BookingDetailsService
    {
        public static List<BookingDetailsModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Details, BookingDetailsModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingDetailsModel>>(ManagerDataAccessFactory.BookingDetailsServiceDataAccess().Get());
            return data;
        }

        public static BookingDetailsModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking_Details, BookingDetailsModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingDetailsModel>(ManagerDataAccessFactory.BookingDetailsServiceDataAccess().Get(id));
            return data;
        }

        public static void Add(BookingDetailsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDetailsModel, Booking_Details>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Details>(n);
            ManagerDataAccessFactory.BookingDetailsServiceDataAccess().Add(data);
        }

        public static void Edit(BookingDetailsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDetailsModel, Booking_Details>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking_Details>(n);
            ManagerDataAccessFactory.BookingDetailsServiceDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.BookingDetailsServiceDataAccess().Delete(id);
        }

        //======================================================================================================================

        public static List<BookingModel> GetByOrderDate(DateTime order_date)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(ManagerDataAccessFactory.BookingDataAccess().GetByOrderDate(order_date));
            return data;
        }
        public static List<BookingModel> GetByCustomerId(int c_id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(ManagerDataAccessFactory.BookingDataAccess().GetByCustomerId(c_id));
            return data;
        }
        public static List<BookingModel> GetByOrderDateCustomerId(DateTime order_date, int c_id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(ManagerDataAccessFactory.BookingDataAccess().GetByOrderDateCustomerId(order_date, c_id));
            return data;
        }
    }
}

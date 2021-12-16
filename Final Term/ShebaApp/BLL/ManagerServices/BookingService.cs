using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class BookingService
    {
        public static List<BookingModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(ManagerDataAccessFactory.BookingDataAccess().Get());
            return data;
        }

        public static BookingModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingModel>(ManagerDataAccessFactory.BookingDataAccess().Get(id));
            return data;
        }

        public static void Add(BookingModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingModel, Booking>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking>(n);
            ManagerDataAccessFactory.BookingDataAccess().Add(data);
        }

        public static void Edit(BookingModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingModel, Booking>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking>(n);
            ManagerDataAccessFactory.BookingDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.BookingDataAccess().Delete(id);
        }

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

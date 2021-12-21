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
    public class CustomerService
    {
        public static CusProfileModel GetCusUser(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerModel>());
            var mapper1 = new Mapper(config1);
            var data1 = mapper1.Map<List<CustomerModel>>(DataAccessFactory.CustomerUserDataAccess().Get());

            var us = new UserModel();
            var cus = new CustomerModel();

            foreach (var a in data)
            {
                if (a.id == id)
                {
                    us = a;
                    break;
                }
            }

            foreach (var a in data1)
            {
                if (a.user_id == id)
                {
                    cus = a;
                    break;
                }
            }

            var u = new CusProfileModel();

            u.user_id = id;
            u.id = cus.id;
            u.fullname = us.fullname;
            u.address = cus.address;
            u.phone = cus.phone;
            u.password = us.password;

            return u;
        }

        public static int GetID(int id)
        {
            var u = DataAccessFactory.CustomerUserDataAccess().Get(id);
            return u.id;
        }

        public static void EditProfile(CusProfileModel u)
        {
            var cus = DataAccessFactory.CustomerUserDataAccess().Get(u.user_id);
            var us = DataAccessFactory.UserDataAccess().Get(u.user_id);

            cus.phone = u.phone;
            cus.address = u.address;
            cus.updated_at = DateTime.Now;

            us.fullname = u.fullname;
            us.password = u.password;
            us.updated_at = DateTime.Now;

            DataAccessFactory.CustomerUserDataAccess().Edit(cus);
            DataAccessFactory.UserDataAccess().Edit(us);
        }

        public static List<BookingModel> GetBooking(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(DataAccessFactory.BookingDataAccess().Get());

            var b = new List<BookingModel>();

            foreach (var x in data)
            {
                if (x.customer_id == id)
                {
                    b.Add(x);
                }
            }

            return b;
        }

        public static BookingModel GetBookingById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingModel>(DataAccessFactory.BookingDataAccess().Get(id));

            return data;
        }

        public static List<CusBookingDetailModel> GetDetail(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking_Details, BookingDetailModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingDetailModel>>(DataAccessFactory.BookingDetailDataAccess().Get());

            var booking = new List<BookingDetailModel>();
            var s = new List<ServiceModel>();
            var r = new List<CusBookingDetailModel>();
            foreach (var x in data)
            {
                if (x.booking_id == id)
                {
                    var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
                    var mapper1 = new Mapper(config1);
                    var data1 = mapper1.Map<ServiceModel>(DataAccessFactory.ServiceDataAccess().Get(x.service_id));

                    var temp = new CusBookingDetailModel()
                    {
                        name = data1.name,
                        category = data1.category,
                        unit_price = data1.unit_price,
                        discount = x.discount,
                        quantity = x.quantity
                    };
                    r.Add(temp);
                }
            }
            return r;
        }

        public static void CancelBooking(int id)
        {
            var u = DataAccessFactory.BookingDataAccess().Get(id);
            u.status = "Cancelled";
            DataAccessFactory.BookingDataAccess().Edit(u);
        }

        public static List<ServiceModel> GetServices(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceModel>>(DataAccessFactory.ServiceDataAccess().Get());

            var r = new List<ServiceModel>();

            foreach (var x in data)
            {
                if (id == 1 && x.category == "HomeCleaning")
                {
                    r.Add(x);
                }
                else if (id == 2 && x.category == "ApplianceRepair")
                {
                    r.Add(x);
                }
                else if (id == 3 && x.category == "PestControl")
                {
                    r.Add(x);
                }
                else if (id == 5 && x.category == "ApplianceMaintainance")
                {
                    r.Add(x);
                }
                else if (id == 4 && x.category == "Plumbing")
                {
                    r.Add(x);
                }
            }
            return r;
        }

        public static void Checkout(List<CusBookingModel> c)
        {
            var t_cost = 0;
            var dis = 0;
            int c_id = 0;

            foreach (var x in c)
            {
                t_cost += x.total_cost;
                c_id = x.id;
                var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
                var mapper1 = new Mapper(config1);
                var s = mapper1.Map<ServiceModel>(DataAccessFactory.ServiceDataAccess().Get(x.s_id));

                dis += (x.quantity * s.discount_amount);
            }

            //t_cost -= dis;

            var temp = new BookingModel()
            {
                customer_id = c_id,
                total_cost = t_cost,
                order_date = DateTime.Now,
                status = "Pending",
                payment_status = "Unpaid",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingModel, Booking>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Booking>(temp);

            DataAccessFactory.BookingDataAccess().Add(data);

            var b = DataAccessFactory.BookingDataAccess().Get();

            int b_id = data.id;

            foreach (var x in c)
            {
                var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
                var mapper1 = new Mapper(config1);
                var s1 = mapper1.Map<ServiceModel>(DataAccessFactory.ServiceDataAccess().Get(x.s_id));

                var dis1 = (x.quantity * s1.discount_amount);
                var y = new BookingDetailModel()
                {
                    booking_id = b_id,
                    service_id = x.s_id,
                    unit_price = x.unit_price,
                    quantity = x.quantity,
                    discount = dis1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingDetailModel, Booking_Details>());
                var mapper2 = new Mapper(config2);
                var data2 = mapper2.Map<Booking_Details>(y);
                DataAccessFactory.BookingDetailDataAccess().Add(data2);
            }
        }

        public static void AddCustomer(CusUser c)
        {
            var us = DataAccessFactory.UserDataAccess().Get();

            int u_present = 0;

            foreach (var x in us)
            {
                if (x.email == c.email)
                {
                    u_present = 1;
                }
            }

            if (u_present == 0)
            {
                var u = new UserModel()
                {
                    email = c.email,
                    password = c.password,
                    fullname = c.fullname,
                    usertype = "Customer",
                    verification_status = "1",
                    id_status = "Active",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
                var mapper = new Mapper(config);
                var data = mapper.Map<User>(u);

                DataAccessFactory.UserDataAccess().Add(data);

                var cus = new CustomerModel()
                {
                    user_id = data.id,
                    address = c.address,
                    phone = c.phone,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                var config1 = new MapperConfiguration(cfg => cfg.CreateMap<CustomerModel, Customer>());
                var mapper1 = new Mapper(config1);
                var data1 = mapper1.Map<Customer>(cus);

                DataAccessFactory.CustomerUserDataAccess().Add(data1);
            }

        }

        public static List<CouponModel> AvailableCoupon(int id)
        {
            var u = DataAccessFactory.CustomerCouponDataAccess().Get();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer_Coupon, CustomerCouponModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CustomerCouponModel>>(u);

            Dictionary<int, int> cnt = new Dictionary<int, int>();

            foreach (var x in data)
            {
                if (x.customer_id == id)
                {
                    cnt.Add(x.coupon_id, 1);
                }
            }

            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponModel>());
            var mapper1 = new Mapper(config1);
            var data1 = mapper1.Map<List<CouponModel>>(DataAccessFactory.CouponDataAccess().Get());
            var temp = new List<CouponModel>();
            foreach (var x in data1)
            {
                if (x.status == "Expired")
                {
                    continue;
                }
                if (cnt.ContainsKey(x.id) == false)
                {
                    temp.Add(x);
                }
            }

            return temp;
        }

        public static void ApplyToken(CustomerCouponModel c)
        {
            var coupon = DataAccessFactory.CouponDataAccess().Get(c.coupon_id);

            var booking = DataAccessFactory.BookingDataAccess().Get(c.booking_id);

            booking.total_cost -= coupon.amount;
            DataAccessFactory.BookingDataAccess().Edit(booking);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerCouponModel, Customer_Coupon>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Customer_Coupon>(c);

            DataAccessFactory.CustomerCouponDataAccess().Add(data);
        }
    }
}

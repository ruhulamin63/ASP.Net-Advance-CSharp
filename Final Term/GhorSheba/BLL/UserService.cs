using AutoMapper;
using DAL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        public static List<UserModel> GetAll(string utype)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());
            var admins = new List<UserModel>();

            foreach (var a in data)
            {
                if (a.usertype == utype)
                {
                    admins.Add(a);
                }
            }
            return admins;
        }

        public static UserModel Profile(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }

        public static void Profile(UserModel u)
        {
            var us = DataAccessFactory.UserDataAccess().Get(u.id);
            us.fullname = u.fullname;
            us.password = u.password;

            DataAccessFactory.UserDataAccess().Edit(us);
        }

        //*********************************************** Customer CRUD Starts **************************************//

        public static EditCustomerModel GetCusUser(int id)
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

            var u = new EditCustomerModel();

            u.user_id = id;
            u.fullname = us.fullname;
            u.address = cus.address;
            u.phone = cus.phone;
            u.password = us.password;
            u.id_status = us.id_status;

            return u;
        }

        public static int AddCustomer(CusUser u)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            int user_present = 0;

            foreach (var a in data)
            {
                if (a.email == u.email)
                {
                    user_present = 1;
                    break;
                }
            }

            if (user_present == 0)
            {
                var cus = new Customer();
                var us = new User();

                cus.user_id = u.id;
                cus.address = u.address;
                cus.phone = u.phone;
                cus.created_at = u.created_at;
                cus.updated_at = u.updated_at;

                us.email = u.email;
                us.fullname = u.fullname;
                us.password = u.password;
                us.id_status = u.id_status;
                us.usertype = u.usertype;
                us.verification_status = u.verification_status;
                us.created_at = u.created_at;
                us.updated_at = u.updated_at;

                DataAccessFactory.UserDataAccess().Add(us);
                cus.user_id = us.id;

                DataAccessFactory.CustomerUserDataAccess().Add(cus);

                return 1;
            }
            return 0;

        }

        public static void EditCustomer(EditCustomerModel u)
        {
            var cus = DataAccessFactory.CustomerUserDataAccess().Get(u.user_id);
            var us = DataAccessFactory.UserDataAccess().Get(u.user_id);

            us.fullname = u.fullname;
            us.password = u.password;
            us.id_status = u.id_status;
            us.updated_at = DateTime.Now;
            DataAccessFactory.UserDataAccess().Edit(us);

            cus.address = u.address;
            cus.phone = u.phone;
            cus.updated_at = DateTime.Now;
            DataAccessFactory.CustomerUserDataAccess().Edit(cus);
        }

        public static int DeleteCustomer(int id)
        {
            try
            {
                var cus = DataAccessFactory.CustomerUserDataAccess().Get(id);
                var us = DataAccessFactory.UserDataAccess().Get(id);

                var bookings = DataAccessFactory.BookingDataAccess().Get();
                var CustomerCoupons = DataAccessFactory.CustomerCouponDataAccess().Get();
                var Reviews = DataAccessFactory.ReviewDataAccess().Get();
                var LoginTimes = DataAccessFactory.LoginTimeDataAccess().Get();
                var tokens = DataAccessFactory.TokenDataAccess().Get();
                var customers = DataAccessFactory.CustomerUserDataAccess().Get();
                var uu = DataAccessFactory.UserDataAccess().Get();

                foreach (var c in bookings)
                {
                    if (c.customer_id == cus.id)
                    {
                        DataAccessFactory.BookingDataAccess().Delete(cus.id);
                    }
                }

                foreach (var c in CustomerCoupons)
                {
                    if (c.customer_id == cus.id)
                    {
                        DataAccessFactory.CustomerCouponDataAccess().Delete(cus.id);
                    }
                }

                foreach (var c in Reviews)
                {
                    if (c.customer_id == cus.id)
                    {
                        DataAccessFactory.ReviewDataAccess().Delete(cus.id);
                    }
                }

                foreach (var c in LoginTimes)
                {
                    if (c.user_id == us.id)
                    {
                        DataAccessFactory.LoginTimeDataAccess().Delete(us.id);
                    }
                }

                foreach (var c in tokens)
                {
                    if (c.user_id == us.id)
                    {
                        DataAccessFactory.TokenDataAccess().Delete(us.id);
                    }
                }

                foreach (var c in customers)
                {
                    if (c.user_id == us.id)
                    {
                        DataAccessFactory.CustomerUserDataAccess().Delete(us.id);
                    }
                }

                foreach (var c in uu)
                {
                    if (c.id == us.id)
                    {
                        DataAccessFactory.UserDataAccess().Delete(us.id);
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //******************************************************** Customer CRUD ends ********************************//

        //******************************************************** Service Provider CRUD starts **********************//

        public static EditServiceProviderModel GetServUser(int id)
        {
            var us = new User();
            var serv = new ServiceProvider();

            us = DataAccessFactory.UserDataAccess().Get(id);
            serv = DataAccessFactory.ServUserDataAccess().Get(id);

            var u = new EditServiceProviderModel();

            u.user_id = id;
            u.fullname = us.fullname;
            u.password = us.password;
            u.id_status = us.id_status;
            u.phone = serv.phone;
            u.work_status = serv.work_status;

            return u;
        }

        public static int AddServiceProvider(ServUserModel u)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            int user_present = 0;

            foreach (var a in data)
            {
                if (a.email == u.email)
                {
                    user_present = 1;
                    break;
                }
            }

            if (user_present == 0)
            {
                var sp = new ServiceProvider();
                var us = new User();

                sp.rating = 0;
                sp.rating_count = 0;
                sp.services_done = 0;
                sp.work_status = "Available";
                sp.created_at = u.created_at;
                sp.updated_at = u.updated_at;

                us.email = u.email;
                us.fullname = u.fullname;
                us.password = u.password;
                us.id_status = u.id_status;
                us.usertype = u.usertype;
                us.verification_status = u.verification_status;
                us.created_at = u.created_at;
                us.updated_at = u.updated_at;

                DataAccessFactory.UserDataAccess().Add(us);
                sp.user_id = us.id;

                DataAccessFactory.ServUserDataAccess().Add(sp);

                return 1;
            }
            return 0;
        }

        public static void EditServiceProvider(EditServiceProviderModel u)
        {
            var sp = DataAccessFactory.ServUserDataAccess().Get(u.user_id);
            var us = DataAccessFactory.UserDataAccess().Get(u.user_id);

            us.fullname = u.fullname;
            us.password = u.password;
            us.id_status = u.id_status;
            us.updated_at = DateTime.Now;
            DataAccessFactory.UserDataAccess().Edit(us);

            sp.work_status = u.work_status;
            sp.phone = u.phone;
            sp.updated_at = DateTime.Now;
            DataAccessFactory.ServUserDataAccess().Edit(sp);
        }

        public static int DeleteServiceProvider(int id)
        {
            try
            {
                var sp = DataAccessFactory.ServUserDataAccess().Get(id);
                var us = DataAccessFactory.UserDataAccess().Get(id);

                var bs = DataAccessFactory.BookingServiceDataAccess().Get();
                var reviews = DataAccessFactory.ReviewDataAccess().Get();
                var sb = DataAccessFactory.ServiceProviderBonusDataAccess().Get();
                var LoginTimes = DataAccessFactory.LoginTimeDataAccess().Get();
                var tokens = DataAccessFactory.TokenDataAccess().Get();
                var uu = DataAccessFactory.UserDataAccess().Get();
                var ServiceProvider = DataAccessFactory.ServUserDataAccess().Get();

                foreach (var s in bs)
                {
                    if (s.serviceprovider_id == sp.id)
                    {
                        DataAccessFactory.BookingServiceDataAccess().Delete(sp.id);
                    }
                }

                foreach (var s in reviews)
                {
                    if (s.serviceprovider_id == sp.id)
                    {
                        DataAccessFactory.ReviewDataAccess().Delete(s.customer_id);
                    }
                }

                foreach (var s in sb)
                {
                    if (s.service_provider_id == sp.id)
                    {
                        DataAccessFactory.ServiceProviderBonusDataAccess().Delete(s.service_provider_id);
                    }
                }

                foreach (var s in LoginTimes)
                {
                    if (s.user_id == us.id)
                    {
                        DataAccessFactory.LoginTimeDataAccess().Delete(s.user_id);
                    }
                }

                foreach (var s in tokens)
                {
                    if (s.user_id == us.id)
                    {
                        DataAccessFactory.TokenDataAccess().Delete(s.user_id);
                    }
                }

                foreach (var s in ServiceProvider)
                {
                    if (s.user_id == us.id)
                    {
                        DataAccessFactory.ServUserDataAccess().Delete(s.user_id);
                    }
                }

                foreach (var s in uu)
                {
                    if (s.id == us.id)
                    {
                        DataAccessFactory.UserDataAccess().Delete(s.id);
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //******************************************* Service Provider CRUD ends ***********************//

        //******************************************* Manager CRUD starts *******************************//

        public static int AddManager(UserModel u)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());

            int user_present = 0;

            foreach (var a in data)
            {
                if (a.email == u.email)
                {
                    user_present = 1;
                    break;
                }
            }

            if (user_present == 0)
            {
                var us = new User();

                us.email = u.email;
                us.fullname = u.fullname;
                us.password = u.password;
                us.id_status = u.id_status;
                us.usertype = u.usertype;
                us.verification_status = u.verification_status;
                us.created_at = u.created_at;
                us.updated_at = u.updated_at;

                DataAccessFactory.UserDataAccess().Add(us);

                return 1;
            }
            return 0;

        }

        public static EditUserModel GetManager(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, EditUserModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<EditUserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }

        public static int EditManager(EditUserModel u)
        {
            try
            {
                var us = DataAccessFactory.UserDataAccess().Get(u.id);
                us.fullname = u.fullname;
                us.password = u.password;
                us.id_status = u.id_status;
                us.updated_at = DateTime.Now; ;
                DataAccessFactory.UserDataAccess().Edit(us);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            };
        }

        public static int DeleteManager(int id)
        {
            try
            {
                DataAccessFactory.UserDataAccess().Delete(id);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            };
        }

        //******************************************* Manager CRUD ends *******************************//

        //******************************************* Services CRUD starts *******************************//

        public static List<ServiceModel> GetServices(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceModel>>(DataAccessFactory.ServiceDataAccess().Get());

            var s = new List<ServiceModel>();
            string category = "";

            if (id == 1)
            {
                category = "HomeCleaning";
            }
            else if (id == 2)
            {
                category = "ApplianceRepair";
            }
            else if (id == 3)
            {
                category = "PestControl";
            }
            else if (id == 4)
            {
                category = "ApplianceMaintainance";
            }
            else if (id == 5)
            {
                category = "Plumbing";
            }

            foreach (var a in data)
            {
                if (a.category == category)
                {
                    s.Add(a);
                }
            }

            return s;
        }

        public static void AddServices(ServiceModel s)
        {
            var service = new Service();
            service.name = s.name;
            service.category = s.category;
            service.unit_price = s.unit_price;
            service.description = s.description;
            service.discount_amount = 0;
            service.created_at = DateTime.Now;
            service.updated_at = DateTime.Now;

            DataAccessFactory.ServiceDataAccess().Add(service);
        }

        public static EditServiceModel GetService(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, EditServiceModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<EditServiceModel>(DataAccessFactory.ServiceDataAccess().Get(id));
            return data;
        }

        public static List<ServiceModel> GetServices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceModel>>(DataAccessFactory.ServiceDataAccess().Get());
            return data;
        }

        public static void EditServices(EditServiceModel s)
        {
            var service = DataAccessFactory.ServiceDataAccess().Get(s.id);
            service.id = s.id;
            service.name = s.name;
            service.description = s.description;
            service.unit_price = s.unit_price;
            service.discount_amount = s.discount_amount;
            service.updated_at = DateTime.Now;

            DataAccessFactory.ServiceDataAccess().Edit(service);
        }

        public static int DeleteServices(int id)
        {
            try
            {
                DataAccessFactory.ServiceDataAccess().Delete(id);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //******************************************* Services CRUD ends *******************************//

        //******************************************* Booking CRUD starts *******************************//
        public static List<BookingModel> GetBookings()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingModel>>(DataAccessFactory.BookingDataAccess().Get());
            return data;
        }

        public static BookingModel GetBookingsLastMonth(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingModel>(DataAccessFactory.BookingDataAccess().Get(id));
            return data;
        }

        public static BookingModel GetBooking(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BookingModel>(DataAccessFactory.BookingDataAccess().Get(id));
            return data;
        }
        public static void EditBooking(BookingModel b)
        {
            var booking = DataAccessFactory.BookingDataAccess().Get(b.id);
            booking.order_date = b.order_date;
            booking.payment_status = b.payment_status;
            booking.status = b.status;
            booking.total_cost = b.total_cost;
            booking.updated_at = DateTime.Now;
            DataAccessFactory.BookingDataAccess().Edit(booking);
        }

        public static List<AdminBookingDetailModel> GetBookingDetails(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking_Details, BookingDetailModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingDetailModel>>(DataAccessFactory.BookingDetailDataAccess().Get());

            var bd = new List<AdminBookingDetailModel>();

            foreach (var b in data)
            {
                if (b.booking_id == id)
                {
                    var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceModel>());
                    var mapper1 = new Mapper(config1);
                    var data1 = mapper1.Map<ServiceModel>(DataAccessFactory.ServiceDataAccess().Get(b.service_id));
                    var temp = new AdminBookingDetailModel()
                    {
                        service_id = b.service_id,
                        name = data1.name,
                        category = data1.category,
                        unit_price = b.unit_price,
                        quantity = b.quantity,
                        discount = b.discount
                    };
                    bd.Add(temp);
                }
            }
            return bd;
        }

        public static List<BookingDetailModel> GetBookingDetails()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking_Details, BookingDetailModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BookingDetailModel>>(DataAccessFactory.BookingDetailDataAccess().Get());

            return data;
        }

        //******************************************* Booking CRUD Ends *******************************//

        //******************************************* Coupon CRUD starts *******************************//

        public static List<CouponModel> GetCoupons()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponModel>>(DataAccessFactory.CouponDataAccess().Get());
            return data;
        }

        public static CouponModel GetCoupon(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponModel>(DataAccessFactory.CouponDataAccess().Get(id));
            return data;
        }

        public static void EditCoupon(CouponModel c)
        {
            var coupon = DataAccessFactory.CouponDataAccess().Get(c.id);
            coupon.amount = c.amount;
            coupon.max_use_number = c.max_use_number;
            coupon.min_order_amount = c.min_order_amount;
            coupon.status = c.status;
            coupon.updated_at = c.updated_at;
            DataAccessFactory.CouponDataAccess().Edit(coupon);
        }

        public static void AddCoupon(CouponModel c)
        {
            var coupon = new Coupon();
            coupon.amount = c.amount;
            coupon.max_use_number = c.max_use_number;
            coupon.min_order_amount = c.min_order_amount;
            coupon.status = c.status;
            coupon.created_at = DateTime.Now;
            coupon.updated_at = DateTime.Now;

            DataAccessFactory.CouponDataAccess().Add(coupon);
        }
        public static int DeleteCoupon(int id)
        {
            try
            {
                DataAccessFactory.CouponDataAccess().Delete(id);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //******************************************* Coupon CRUD ends *******************************//

        //******************************************* Assign SP ends *******************************//

        public static List<ServiceProviderModel> GetSP()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceProvider, ServiceProviderModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ServiceProviderModel>>(DataAccessFactory.ServUserDataAccess().Get());
            var SP = new List<ServiceProviderModel>();

            foreach (var s in data)
            {
                if (s.work_status == "Available")
                {
                    SP.Add(s);
                }
            }
            return SP;
        }

        public static void ConfirmBooking(BookingServiceModel s)
        {

            var booking = DataAccessFactory.BookingDataAccess().Get(s.booking_id);

            booking.status = "Confirmed";
            booking.payment_status = "Unpaid";
            booking.updated_at = DateTime.Now;
            DataAccessFactory.BookingDataAccess().Edit(booking);

            var sp = DataAccessFactory.ServiceProviderDataAccess().Get(s.serviceprovider_id);
            sp.work_status = "Busy";
            DataAccessFactory.ServiceProviderDataAccess().Edit(sp);

            var bs = new Booking_Service();
            bs.serviceprovider_id = s.serviceprovider_id;
            bs.booking_id = s.booking_id;
            DataAccessFactory.BookingServiceDataAccess().Add(bs);
        }

        public static List<UserSalariesModel> ViewSalaries()
        {
            var us = DataAccessFactory.UserDataAccess().Get();

            foreach (var x in us)
            {
                if (x.usertype == "Manager")
                {
                    var s = DataAccessFactory.SalariesDataAccess().Get(x.id);
                    if (s == null)
                    {
                        var temp = new SalariesModel()
                        {
                            salary_amount = 40000,
                            message = "Paid",
                            user_id = x.id,
                            created_at = DateTime.Now,
                            updated_at = DateTime.Now
                        };

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<SalariesModel, Salary>());
                        var mapper = new Mapper(config);
                        var data = mapper.Map<Salary>(temp);

                        DataAccessFactory.SalariesDataAccess().Add(data);
                    }
                }
                else if (x.usertype == "ServiceProvider")
                {
                    var s = DataAccessFactory.SalariesDataAccess().Get(x.id);
                    if (s == null)
                    {
                        var temp = new SalariesModel()
                        {
                            salary_amount = 8000,
                            message = "Paid",
                            user_id = x.id,
                            created_at = DateTime.Now,
                            updated_at = DateTime.Now
                        };

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<SalariesModel, Salary>());
                        var mapper = new Mapper(config);
                        var data = mapper.Map<Salary>(temp);

                        DataAccessFactory.SalariesDataAccess().Add(data);
                    }
                }
            }

            var sal = DataAccessFactory.SalariesDataAccess().Get();

            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<Salary, SalariesModel>());
            var mapper1 = new Mapper(config1);
            var data1 = mapper1.Map<List<SalariesModel>>(sal);

            var r = new List<UserSalariesModel>();

            foreach (var x in data1)
            {
                var u = DataAccessFactory.UserDataAccess().Get(x.user_id);
                DateTime dt = x.updated_at.AddDays(30);
                var temp = new UserSalariesModel()
                {
                    fullname = u.fullname,
                    email = u.email,
                    salary_amount = x.salary_amount,
                    message = x.message,
                    user_id = u.id,
                    last_paid = x.updated_at,
                    Due = (int)(dt - DateTime.Now.Date).TotalDays
                };
                r.Add(temp);
            }
            return r;
        }

        public static void PaySalary(int id)
        {
            var sal = DataAccessFactory.SalariesDataAccess().Get(id);
            sal.updated_at = DateTime.Now;
            DataAccessFactory.SalariesDataAccess().Edit(sal);
        }
    }
}

using DAL.ManagerRepository;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerDataAccessFactory
    {
        static ShebaDbEntities db;

        static ManagerDataAccessFactory()
        {
            db = new ShebaDbEntities();
        }

        public static ManagerInterface<User, int> UserDataAccess()
        {
            return new UserRepository(db);
        }
        public static ManagerInterface<Booking, int> BookingDataAccess()
        {
            return new BookingRepository(db);
        }
        public static ManagerInterface<Booking_Service, int> BookingServiceDataAccess()
        {
            return new BookingServiceRepository(db);
        }
        public static ManagerInterface<Booking_Details, int> BookingDetailsServiceDataAccess()
        {
            return new BookingDetailsRepository(db);
        }
        public static ManagerInterface<Service, int> ServiceDataAccess()
        {
            return new ServiceRepository(db);
        }
        public static ManagerServiceProviderInterface<ServiceProvider, int> ServiceProviderDataAccess()
        {
            return new ServiceProviderRepository(db);
        } 
        public static ManagerInterface<Coupon, int> CouponServiceDataAccess()
        {
            return new CouponRepository(db);
        }
        public static ManagerInterface<Review, int> ReviewDataAccess()
        {
            return new ReviewRepository(db);
        }

        public static ManagerInterface<Customer, int> CustomerDataAccess()
        {
            return new CustomerRepository(db);
        }
        public static Salary_Interface<Salary, int> SalaryDataAccess()
        {
            return new SalaryRepository(db);
        }
       /* public static Salary_Interface<Discount, int> DiscountDataAccess()
        {
            return new DiscountRepository(db);
        }*/
    }
}

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

        public static ManagerRepository<User, int> UserDataAccess()
        {
            return new UserRepository(db);
        }
        public static ManagerRepository<Booking, int> BookingDataAccess()
        {
            return new BookingRepository(db);
        }
        public static ManagerRepository<Booking_Service, int> BookingServiceDataAccess()
        {
            return new BookingServiceRepository(db);
        }
        public static ManagerRepository<Booking_Details, int> BookingDetailsServiceDataAccess()
        {
            return new BookingDetailsRepository(db);
        }
        public static ManagerRepository<Service, int> ServicerToServiceDataAccess()
        {
            return new ServiceRepository(db);
        }
        public static ManagerRepository<ServiceProvider, int> SrviceProviderServiceDataAccess()
        {
            return new ServiceProviderRepository(db);
        } 
        public static ManagerRepository<Coupon, int> CouponServiceDataAccess()
        {
            return new CouponRepository(db);
        }
        public static ManagerRepository<Review, int> ReviewDataAccess()
        {
            return new ReviewRepository(db);
        }

        public static Salary_Interface<Salary, int> SalaryDataAccess()
        {
            return new SalaryRepository(db);
        }
        public static Salary_Interface<Discount, int> DiscountDataAccess()
        {
            return new DiscountRepository(db);
        }
    }
}

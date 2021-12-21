using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static ShebaDbEntities db;
        static DataAccessFactory()
        {
            db = new ShebaDbEntities();
        }
        public static AdminIRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static AdminIRepository<Customer, int> CustomerUserDataAccess()
        {
            return new CustomerCrudRepo(db);
        }

        public static AdminIRepository<Booking, int> BookingDataAccess()
        {
            return new BookingRepo(db);
        }

        public static AdminIRepository<Customer_Coupon, int> CustomerCouponDataAccess()
        {
            return new CustomerCouponRepo(db);
        }

        public static AdminIRepository<Review, int> ReviewDataAccess()
        {
            return new ReviewRepo(db);
        }

        public static AdminIRepository<Login_Time, int> LoginTimeDataAccess()
        {
            return new LoginTimeRepo(db);
        }

        public static AdminIRepository<Token, int> TokenDataAccess()
        {
            return new TokenRepo(db);
        }

        public static AdminIRepository<ServiceProvider, int> ServUserDataAccess()
        {
            return new ServCrudRepo(db);
        }

        public static AdminIRepository<Booking_Service, int> BookingServiceDataAccess()
        {
            return new BookingServiceRepo(db);
        }

        public static AdminIRepository<ServiceProvider_Bonus, int> ServiceProviderBonusDataAccess()
        {
            return new ServiceProviderBonus(db);
        }

        public static AdminIRepository<Service, int> ServiceDataAccess()
        {
            return new ServiceRepo(db);
        }

        public static AdminIRepository<Booking_Details, int> BookingDetailDataAccess()
        {
            return new BookingDetailRepo(db);
        }

        public static AdminIRepository<Coupon, int> CouponDataAccess()
        {
            return new CouponRepo(db);
        }

        public static AdminIRepository<ServiceProvider, int> ServiceProviderDataAccess()
        {
            return new ServiceProviderRepo(db);
        }

        public static AdminIRepository<Salary, int> SalariesDataAccess ()
        {
            return new SalariesRepo(db);
        }
    }
}

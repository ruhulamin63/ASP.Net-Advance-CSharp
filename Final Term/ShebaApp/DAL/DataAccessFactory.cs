using DAL.Interface_Repository;
using DAL.ManagerRepository;
using DAL.Repository;
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

        public static UserInterface<User, int> UserDataAccess()
        {
            return new UserRepository(db);
        }
        public static BookingInterface<Booking, int> BookingDataAccess()
        {
            return new BookingRepository(db);
        }
        public static IRepository<Booking_Service, int> BookingServiceDataAccess()
        {
            return new BookingServiceRepository(db);
        }
        public static BookingDetailsInterface<Booking_Details, int> BookingDetailsServiceDataAccess()
        {
            return new BookingDetailsRepository(db);
        }
        public static IRepository<Service, int> ServicerToServiceDataAccess()
        {
            return new ServiceRepository(db);
        }
        public static IRepository<ServiceProvider, int> SrviceProviderServiceDataAccess()
        {
            return new ServiceProviderRepository(db);
        } 
        public static CouponInterface<Coupon, int> CouponServiceDataAccess()
        {
            return new CouponRepository(db);
        }
    }
}

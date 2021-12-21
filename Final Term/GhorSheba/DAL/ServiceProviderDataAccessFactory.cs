using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceProviderDataAccessFactory
    {
        static ShebaDbEntities db;
        static ServiceProviderDataAccessFactory()
        {
            db = new ShebaDbEntities();
        }

        public static ServiceProviderIRepository<ServiceProvider, int> ServiceProviderDataAccess()
        {
            return new ServiceProviderRepo1(db);
        }

        public static ServiceProviderIRepository<User, int> UserProDataAccess()
        {
            return new UserProRepo(db);
        }

        public static ServiceProviderIRepository<Booking, int> SerBookingDataAccess()
        {
            return new SerBookingRepo(db);
        }
        public static ServiceProviderIRepository<Booking_Service, int> SerBooking_ServiceDataAccess()
        {
            return new SerBooking_ServiceRepo(db);
        }

        public static ServiceProviderIRepository<Review, int> SerReviewDataAccess()
        {
            return new SerReviewRepo(db);
        }

        public static ServiceProviderIRepository<Bonu, int> SerBonusDataAccess()
        {
            return new SerBonusRepo(db);
        }

        public static ServiceProviderIRepository<ServiceProvider_Bonus, int> ServiceProvider_BonusDataAccess()
        {
            return new ServiceProvider_BonusRepo(db);
        }

        public static ServiceProviderIRepository<Service, int> Service_DetailDataAccess()
        {
            return new ServiceDetailRepo(db);
        }
        
    }
}

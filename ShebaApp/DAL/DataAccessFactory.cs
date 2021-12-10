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

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepository(db);
        }
        public static IRepository<Booking, int> BookingDataAccess()
        {
            return new BookingRepository(db);
        }
        public static IRepository<Booking_Service, int> BookingServiceDataAccess()
        {
            return new BookingServiceRepository(db);
        }
    }
}

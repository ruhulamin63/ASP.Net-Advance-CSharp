using Ghor_Sheba.Models;
using Ghor_Sheba.Models.ManagerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class ServiceAssignRepository
    {
        static ShebaDbEntities db;

        static ServiceAssignRepository()
        {
            db = new ShebaDbEntities();
        }

        public static BookingConfirmModel Get(int Id)
        {
            var b = (from bk in db.Booking_confirms
                     where bk.id == Id
                     select bk).FirstOrDefault();

            return new BookingConfirmModel()
            {
                id = b.id,
                booking_id = b.booking_id,
                service_provider_id = b.service_provider_id,
                status = b.status
            };
        }

        public static void PlaceAssignServiceProvider(int bId, int sp_id)
        {
            /*Booking_confirms bc = new Booking_confirms();

            bc.booking_id = bId;
            bc.service_provider_id = sp_id;
            bc.status = "busy";*/

            var cs = new Booking_confirms()
            {
                booking_id = bId,
                service_provider_id = sp_id,
                status = "busy"
            };
            db.Booking_confirms.Add(cs);
            db.SaveChanges();
        }

        public static List<Booking_confirms> MyServiceProviderAssign(int id)
        {
            //return db.orders.Where(e => e.id == id).ToList();

            var orders = (from e in db.Booking_confirms
                          where e.booking_id == id
                          select e);

            return orders.ToList();
        }
    }
}
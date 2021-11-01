using Ghor_Sheba.Models;
using Ghor_Sheba.Models.ManagerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class BookingConfirmRepository
    {
        static ShebaDbEntities db;

        static BookingConfirmRepository()
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

        public static List<BookingConfirmModel> GetAll()
        {
            var product = new List<BookingConfirmModel>();

            foreach (var b in db.Booking_confirms)
            {
                BookingConfirmModel pm = new BookingConfirmModel()
                {
                    id = b.id,
                    booking_id = b.booking_id,
                    service_provider_id = b.service_provider_id,
                    status = b.status
                };
                product.Add(pm);
            }
            return product;
        }
    }
}
using Ghor_Sheba.Models;
using Ghor_Sheba.Models.ManagerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class BookingRepository
    {
        static ShebaDbEntities db;

        static BookingRepository()
        {
            db = new ShebaDbEntities();
        }

        public static BookingModel Get(int Id)
        {
            var b = (from bk in db.Bookings
                     where bk.id == Id
                     select bk).FirstOrDefault();

            return new BookingModel()
            {
                id = b.id,
                customer_id = b.customer_id,
                cost = b.cost,
                status = b.status,
                payment_status = b.payment_status,
            };
        }

        public static List<BookingModel> GetAll()
        {
            var product = new List<BookingModel>();

            foreach (var b in db.Bookings)
            {
                BookingModel pm = new BookingModel()
                {
                    id = b.id,
                    customer_id = b.customer_id,
                    cost = b.cost,
                    status = b.status,
                    payment_status = b.payment_status,
                };
                product.Add(pm);
            }
            return product;
        }
    }
}
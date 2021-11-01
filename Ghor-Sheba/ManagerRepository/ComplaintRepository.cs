using Ghor_Sheba.Models;
using Ghor_Sheba.Models.ManagerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class ComplaintRepository
    {
        static ShebaDbEntities db;

        static ComplaintRepository()
        {
            db = new ShebaDbEntities();
        }

        public static ComplaintModel Get(int Id)
        {
            var b = (from bk in db.Complaints
                     where bk.id == Id
                     select bk).FirstOrDefault();

            return new ComplaintModel()
            {
                id = b.id,
                customer_id = b.customer_id,
                description = b.description,
                status = b.status
            };
        }

        public static List<ComplaintModel> GetAll()
        {
            var product = new List<ComplaintModel>();

            foreach (var b in db.Complaints)
            {
                ComplaintModel pm = new ComplaintModel()
                {
                    id = b.id,
                    customer_id = b.customer_id,
                    description = b.description,
                    status = b.status
                };
                product.Add(pm);
            }
            return product;
        }

        public static void Unread_to_Read(int id)
        {
            var b = (from bk in db.Complaints
                     where bk.id == id && bk.status=="unread"
                     select bk).FirstOrDefault();

            var cs = new Complaint()
            {
                id = b.id,
                customer_id = b.customer_id,
                description = b.description,
                status = "read"
            };

            db.Complaints.Remove(b);
            db.Complaints.Add(cs);
            db.SaveChanges();
        }
    }
}
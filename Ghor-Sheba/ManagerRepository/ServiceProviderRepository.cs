using Ghor_Sheba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class ServiceProviderRepository
    {
        static ShebaDbEntities db;

        static ServiceProviderRepository()
        {
            db = new ShebaDbEntities();
        }

        public static ServiceProviderModel Get(int Id)
        {
            var b = (from bk in db.service_provider_status
                     where bk.id == Id
                     select bk).FirstOrDefault();

            return new ServiceProviderModel()
            {
                id = b.id,
                service_provider_id = b.service_provider_id,
                status = b.status
            };
        }

        public static List<ServiceProviderModel> GetAll()
        {
            var spm = new List<ServiceProviderModel>();

            foreach (var b in db.service_provider_status)
            {
                ServiceProviderModel sp = new ServiceProviderModel()
                {
                    id = b.id,
                    service_provider_id = b.service_provider_id,
                    status = b.status
                };
                spm.Add(sp);
            }
            return spm;
        }
    }
}
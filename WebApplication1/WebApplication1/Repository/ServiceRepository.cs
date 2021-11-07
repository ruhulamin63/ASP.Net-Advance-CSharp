using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EF;
using WebApplication1.Models.VM;

namespace WebApplication1.Repository
{
    public class ServiceRepository
    {
        static ShebaDbEntities db;

        static ServiceRepository()
        {
            db = new ShebaDbEntities();
        }

        public static ServiceModel Get(int Id)
        {
            var p = (from pr in db.Services
                     where pr.id == Id
                     select pr).FirstOrDefault();

            return new ServiceModel()
            {
                id = p.id,
                name = p.name,
                category = p.category,
                description = p.description
            };
        }

        public static List<ServiceModel> GetAll()
        {
            var product = new List<ServiceModel>();

            foreach (var p in db.Services)
            {
                ServiceModel pm = new ServiceModel()
                {
                    id = p.id,
                    name = p.name,
                    category = p.category,
                    description = p.description
                };
                product.Add(pm);
            }
            return product;
        }
    }
}
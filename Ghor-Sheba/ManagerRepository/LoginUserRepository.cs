using Ghor_Sheba.Models;
using Ghor_Sheba.Models.ManagerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class LoginUserRepository
    {
        static ShebaDbEntities db;

        static LoginUserRepository()
        {
            db = new ShebaDbEntities();
        }

        public static List<LoginUserModel> GetAll()
        {
            var product = new List<LoginUserModel>();

            foreach (var b in db.LoginUsers)
            {
                LoginUserModel pm = new LoginUserModel()
                {
                    id = b.id,
                    username = b.username,
                    fullname = b.fullname,
                    address = b.address,
                    phone = b.phone,
                    email = b.email,
                    status = b.status,
                };
                product.Add(pm);
            }
            return product;
        }
    }
}
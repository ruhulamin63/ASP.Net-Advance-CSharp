using Ghor_Sheba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghor_Sheba.ManagerRepository
{
    public class ManagerProfileRepository
    {
        static ShebaDbEntities db;

        static ManagerProfileRepository()
        {
            db = new ShebaDbEntities();
        }

        public static LoginUser GetProfileInfo(int id)
        {
            var user = (from u in db.LoginUsers
                        where u.id == id
                        select u).FirstOrDefault();
            return user;

        }

        public static LoginUser GetEditInfo(int id)
        {
            var user = (from u in db.LoginUsers
                        where u.id == id
                        select u).FirstOrDefault();
            return user;

        }

        public static LoginUser Get_Password_Info(int id)
        {
            var user = (from u in db.LoginUsers
                        where u.id == id
                        select u).FirstOrDefault();
            return user;

        }
    }
}
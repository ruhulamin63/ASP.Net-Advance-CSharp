using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthDataAccessFactory
    {
        static ShebaDbEntities db;
        static AuthDataAccessFactory()
        {
            db = new ShebaDbEntities();
        }

        public static AdminIRepository<Token, string> TokenDataAccess()
        {
            return new TokenRepo1(db);
        }
        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }

        public static AdminIRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
    }
}

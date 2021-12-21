using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthRepo : IAuth
    {
        ShebaDbEntities db;

        public AuthRepo(ShebaDbEntities db) {
            this.db = db;
        }
        public Token Authenticate(User user)
        {
            Token t=null;
            var u =db.Users.FirstOrDefault(e => e.email == user.email && e.password == user.password);
            if (u != null) {

                var to = db.Tokens.FirstOrDefault(e => e.user_id==u.id && e.ExpiredAt==null);
                if (to == null)
                {
                    var r = new Random();
                    var g = Guid.NewGuid();
                    var token = g.ToString();

                    t = new Token()
                    {
                        user_id = u.id,
                        access_token = token,
                        CreatedAt = DateTime.Now

                    };
                    db.Tokens.Add(t);
                    db.SaveChanges();
                    return t;
                }
                else
                {
                    return to;
                }
            }
            return t;

        }
        public bool IsAuthenticated(string token) {
            var ac_token = db.Tokens.FirstOrDefault(e => e.access_token.Equals(token) && e.ExpiredAt == null);
            if (ac_token != null) return true;
            return false;

        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }
    }
}

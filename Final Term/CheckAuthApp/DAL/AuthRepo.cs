using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthRepo : IAuth
    {
        BlogsEntities db;
        public AuthRepo(BlogsEntities db)
        {
            this.db = db;
        }

        public Token Authenticate(User user)
        {
            Token t = null;

            var u = db.Users.FirstOrDefault(e => e.Username == user.Username && e.Password == user.Password);

            if (u != null)
            {
                // var token = "234567"; //dynamic random staring value
                var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();

                t = new Token()
                {
                    UserId = u.Id,
                    AccessToken = token,
                    CreatedAt = DateTime.Now
                };
                db.Tokens.Add(t);
                db.SaveChanges();
            }
            return t;
        }

        public bool IsAuthenticate(string token)
        {
            var ac_token = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token) && e.ExpiredAt == null);

            if (ac_token != null)
            {
                return true;
            }
            return false;
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }
    }
}

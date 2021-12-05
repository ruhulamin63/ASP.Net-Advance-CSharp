using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TokenRepo : IRepository<Token, string>
    {
        BlogsEntities db;
        public TokenRepo(BlogsEntities db)
        {
            this.db = db;
        }
        public bool Add(Token e)
        {
            db.Tokens.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(string token)
        {
            db.Tokens.Remove(db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token)));
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Token e)
        {
            var token = db.Tokens.FirstOrDefault(en => en.AccessToken.Equals(e.AccessToken));
            db.Entry(token).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
        }
    }
}

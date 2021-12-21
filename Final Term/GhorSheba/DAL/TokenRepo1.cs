using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TokenRepo1 : AdminIRepository<Token, string>
    {
        ShebaDbEntities db;
        public TokenRepo1(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Token e)
        {
            db.Tokens.Add(e);
            db.SaveChanges();
        }

        public void Delete(string token)
        {
            db.Tokens.Remove(db.Tokens.FirstOrDefault(e => e.access_token.Equals(token)));
            db.SaveChanges();
        }

        public void Edit(Token e)
        {
            var token = db.Tokens.FirstOrDefault(en => en.access_token.Equals(e.access_token));
            db.Entry(token).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(e => e.access_token.Equals(token));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TokenRepo : AdminIRepository<Token, int>
    {
        ShebaDbEntities db;
        public TokenRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Token e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var e = db.Tokens.FirstOrDefault(en => en.user_id == id);
            db.Tokens.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Token e)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.FirstOrDefault(e => e.user_id == id);
        }
    }
}

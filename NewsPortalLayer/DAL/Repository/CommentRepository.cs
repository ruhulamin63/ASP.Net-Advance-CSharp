using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CommentRepository : IRepository<Comment, int>
    {
        NewsPortalDbEntities db;

        public CommentRepository(NewsPortalDbEntities db)
        {
            this.db = db;
        }

        public bool Add(Comment e)
        {
            db.Comments.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Comments.FirstOrDefault(en => en.id == id);
            db.Comments.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Comment e)
        {
            var p = db.Comments.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.FirstOrDefault(e => e.id == id);
        }

        public List<News> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            throw new NotImplementedException();
        }
    }
}

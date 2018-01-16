using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Repositories
{
    //Implementation IRepository which typed Guestbook.
    public class GuestbookRepository : IRepository<Guestbook>
    {
        private BlogContext db;

        public GuestbookRepository(BlogContext context)
        {
            this.db = context;
        }
        public void Create(Guestbook item)
        {
            db.Guestbooks.Add(item);
        }

        public void Delete(int id)
        {
            Guestbook guestbook = db.Guestbooks.Find(id);
            if (guestbook != null)
                db.Guestbooks.Remove(guestbook);
        }

        public Guestbook GetById(int id)
        {
            return db.Guestbooks.Find(id);
        }

        public IEnumerable<Guestbook> GetList()
        {
            return db.Guestbooks;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Guestbook item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

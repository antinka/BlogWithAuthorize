using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogUsingEF.DAL.Repositories
{
    //Using this we will work with db.
   public class EFUnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private GuestbookRepository guestbookRepository;
        private AnketRepository anketRepository;
        private TagRepository tagRepository;
        private ApplicationUserManager applicationUserManager;
        private ApplicationRoleManager  applicationRoleManager;
     
        public EFUnitOfWork(string connectionString)
        {
            db = new BlogContext(connectionString);
            applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            applicationRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
          
        }
        public ApplicationUserManager ApplicationUserManager
        {
            get { return applicationUserManager; }
        }

        public ApplicationRoleManager ApplicationRoleManager
        {
            get { return applicationRoleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }
        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }
        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Guestbook> Guestbooks
        {
            get
            {
                if (guestbookRepository == null)
                    guestbookRepository = new GuestbookRepository(db);
                return guestbookRepository;
            }
        }
        public IRepository<Anket> Ankets
        {
            get
            {
                if (anketRepository == null)
                    anketRepository = new AnketRepository(db);
                return anketRepository;
            }
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

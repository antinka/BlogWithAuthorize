using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUsingEF.DAL.Entities;

namespace BlogUsingEF.DAL.Repositories
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private UserRepository userRepository;
        private GuestbookRepository guestbookRepository;
        private AnketRepository anketRepository;
        public EFUnitOfWork()
        {
            db = new BlogContext();
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

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
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
    }
}

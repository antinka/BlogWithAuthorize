using BlogUsingEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
        IRepository<Comment> Comments { get; }
        IRepository<User> Users { get; }
        IRepository<Guestbook> Guestbooks { get; }
        IRepository<Anket> Ankets { get; }
    }
}

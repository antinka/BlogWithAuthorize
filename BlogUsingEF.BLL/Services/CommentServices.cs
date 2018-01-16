using AutoMapper;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Services
{
   public class CommentServices : ICommentServices
    {
        IUnitOfWork Database { get; set; }
        public CommentServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        // Return all comment to current article.
        public IEnumerable<CommentDTO> GetComments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetList());
        }
        //Add new comment.
        public void AddNewComment(CommentDTO commentDTO, int articleId, string userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, Comment>());
            IMapper mapper = config.CreateMapper();
            commentDTO.DataPublish = DateTime.Now;
            commentDTO.User = Database.ApplicationUserManager.FindById(userId);
            commentDTO.ArticleId = articleId;
            Database.Comments.Create(mapper.Map<CommentDTO, Comment>(commentDTO));
            Database.Comments.Save();
        }
    }
}

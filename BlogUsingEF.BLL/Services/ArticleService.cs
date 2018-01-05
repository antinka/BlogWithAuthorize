using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUsingEF.BLL.DTO;
using AutoMapper;
using BlogUsingEF.DAL.Entities;

namespace BlogUsingEF.BLL.Services
{
    public class ArticleService : IArticleServiceAddGetArticleComment
    {
        IUnitOfWork Database { get; set; }
        public IEnumerable<ArticleDTO> GetArticles()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetList());
        }
        //return all article which has in db
        public ArticleDTO GetArticlesById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            ArticleDTO articleDTO = mapper.Map<Article, ArticleDTO>(Database.Articles.GetById(id));
            return articleDTO;
        }
        // add new article
        public void AddNewArticle(ArticleDTO articleDTO,int userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>());
            IMapper mapper = config.CreateMapper();
            Article article = mapper.Map<ArticleDTO, Article>(articleDTO);
            articleDTO.DataPublish = DateTime.Now;
            articleDTO.UserId = userId;
            Database.Articles.Create(mapper.Map<ArticleDTO, Article>(articleDTO));
            Database.Articles.Save();
        }
        // return all comment to current article
        public IEnumerable<CommentDTO> GetComments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetList());
        }
        //add new comment
        public void AddNewComment(CommentDTO commentDTO, int articleId, int userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, Comment>());
            IMapper mapper = config.CreateMapper();
            Comment comment = mapper.Map<CommentDTO, Comment>(commentDTO);
            commentDTO.DataPublish = DateTime.Now;
            commentDTO.UserId = userId;
            commentDTO.ArticleId = articleId;
            Database.Comments.Create(mapper.Map<CommentDTO, Comment>(commentDTO));
            Database.Comments.Save();
        }

        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        // delete choosen article by id
        public void DeleteArticle(int id)
        {
            Article article = Database.Articles.GetById(id);
            if (article != null)
            {
                Database.Articles.Delete(id);
                var IdDeleteComment = (from c in Database.Comments.GetList() where c.ArticleId == id select c.Id).ToList();
                for (int i = 0; i < IdDeleteComment.Count; i++)
                {
                    Database.Comments.Delete(IdDeleteComment[i]);
                }
                Database.Comments.Save();
            }
        }
    }
}

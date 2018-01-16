using AutoMapper;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlogUsingEF.BLL.Services
{
    public class ArticleService : IArticleServiceAddGetArticleComment
    {
        IUnitOfWork Database { get; set; }
        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        //Get all article in db.
        public IEnumerable<ArticleDTO> GetArticles()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.GetList());
        }
        //Return article choosen by id
        public ArticleDTO GetArticlesById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            ArticleDTO articleDTO = mapper.Map<Article, ArticleDTO>(Database.Articles.GetById(id));
            return articleDTO;
        }
        // Add new article.
        public void AddNewArticle(ArticleDTO articleDTO,string userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>());
            IMapper mapper = config.CreateMapper();
            articleDTO.DataPublish = DateTime.Now;
            articleDTO.User = Database.ApplicationUserManager.FindById(userId);
            Database.Articles.Create(mapper.Map<ArticleDTO, Article>(articleDTO));
            Database.Articles.Save();
        }
        // Delete choosen article by id.
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
        // Add string of tegs to choosen article by id.
        public void AddTagsToArticle(int articleId, string tags)
        {
            Article article = Database.Articles.GetById(articleId);
            article.Tags = tags;
            Database.Articles.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

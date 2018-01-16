using BlogUsingEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
    public interface IArticleServiceAddGetArticleComment
    {
        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticlesById(int id);
        void AddNewArticle(ArticleDTO articleDTO, string userId);
        void AddTagsToArticle(int articleId, string tags);
        void DeleteArticle(int id);
        void Dispose();
    }
}

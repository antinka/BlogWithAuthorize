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
        IEnumerable<CommentDTO> GetComments();
        ArticleDTO GetArticlesById(int id);
        void AddNewArticle(ArticleDTO articleDTO, int userId);
        void AddNewComment(CommentDTO commentDTO, int articleId, int userId);
        void DeleteArticle(int id);
    }
}

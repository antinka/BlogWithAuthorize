using BlogUsingEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
   public interface ICommentServices
    {
        void AddNewComment(CommentDTO commentDTO, int articleId, string userId);
        IEnumerable<CommentDTO> GetComments();

    }
}

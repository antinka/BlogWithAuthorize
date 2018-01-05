using BlogUsingEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IList<ArticleDTO> Articles { get; set; }
        public IList<CommentDTO> Comments { get; set; }
    }
}

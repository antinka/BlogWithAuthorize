using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public DateTime? DataPublish { get; set; }
        public string Text { get; set; }
        public ArticleDTO Article { get; set; }
        public int? ArticleId { get; set; }
        public UserDTO User { get; set; }
        public int? UserId { get; set; }
    }
}

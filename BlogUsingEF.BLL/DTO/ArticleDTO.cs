using BlogUsingEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DataPublish { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public string Tags { get; set; }
    }
}

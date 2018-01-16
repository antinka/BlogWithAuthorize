using System;
using System.ComponentModel.DataAnnotations;

namespace BlogUsingEF.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataPublish { get; set; }
        public string Text { get; set; }
        public Article Article { get; set; }
        public int? ArticleId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
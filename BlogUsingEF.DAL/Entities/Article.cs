using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogUsingEF.DAL.Entities
{
    public class Article
    { 
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DataPublish { get; set; }
        public string Text { get; set; }
        public ApplicationUser User { get; set; }
        public IList<Comment> Comments { get; set; }
        public string Tags { get; set; }
    }
}
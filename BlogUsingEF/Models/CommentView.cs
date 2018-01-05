using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogUsingEF.Models
{
    public class CommentView
    {
        public int Id { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime? DataPublish { get; set; }
        [Display(Name = "Коментарий")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите текст коментария")]
        public string Text { get; set; }
        public int ArticleId { get; set; }
       
    }
}
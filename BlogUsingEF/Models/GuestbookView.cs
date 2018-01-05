using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogUsingEF.Models
{
    public class GuestbookView
    {
        public int Id { get; set; }
        [Display(Name = "Имя автора")]
        public string NameAuthor { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime? DataPublish { get; set; }
        [Display(Name = "Отзыв")]
        public string Text { get; set; }
    }
}
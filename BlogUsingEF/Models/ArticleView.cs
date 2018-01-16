using BlogUsingEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogUsingEF.Models
{
    public class ArticleView
    {
        public int Id { get; set; }
        [Display(Name = "Заголовок")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }
        [Display(Name = "Статья")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите текст статьи")]
        public string Text { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime? DataPublish { get; set; }
        [Display(Name = "Ключевые слова #")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите ключевые слова")]
        public string Tags { get; set; }
        public int UserId { get; set; }

    }
}
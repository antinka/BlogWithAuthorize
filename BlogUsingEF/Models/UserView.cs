using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogUsingEF.Models
{
    public class UserView
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        public string FullName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя пользователя")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Пароль должен содержать как минимум 3 символа")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLogin
    {
        [Display(Name = "Электронная почта")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно введите Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
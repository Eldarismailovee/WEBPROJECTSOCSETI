using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class Users
    {
        public string ConfirmPassword { get; set; }
    }
    public class UserMetaData
    {
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно введите имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно введите фамилию")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательно введите Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateofBirth { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Минимальная длина пароля 6 символов")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        public string ConfirmPassword { get; set; }

    }
}
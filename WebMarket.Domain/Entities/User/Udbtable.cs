using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Domain.Entities.User
{
     class Udbtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        [StringLength(30,MinimumLength = 5,ErrorMessage ="Имя пользователся должно быть не длинее 30 символов")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль должен быть не короче 8 символов")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email адресс")]
        [StringLength(30)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }
        [StringLength(30)]
        public string lastIp { get; set; }
        public URole Level { get; set; }
    }
}

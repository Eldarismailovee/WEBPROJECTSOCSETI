using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "User Name or Email")]
        public string Credential { get; internal set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; internal set; }
    }
}
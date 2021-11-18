using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veilig.Models
{
    public class LoginModel
    {
        [DisplayName("User name")]
        [Required(ErrorMessage ="User name is required")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
        [HiddenInput]
        public string RedirectUrl { get; set; }
    }
}

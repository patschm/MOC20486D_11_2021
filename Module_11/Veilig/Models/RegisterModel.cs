using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veilig.Models
{
    public class RegisterModel
    {
        [DisplayName("User name")]
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords niet hetzelfde")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}

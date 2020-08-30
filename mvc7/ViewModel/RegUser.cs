using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace muscshop.ViewModel
{
    public class RegUser
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Max Lenght: 20 Symbols")]
        [MinLength(8, ErrorMessage = "Min Lenght: 8 Symbols")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Min Lenght: 8 Symbols")]
        [MaxLength(24, ErrorMessage = "Max Lenght: 24 Symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password istn't Equal")]
        public string ConfigmPassword { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
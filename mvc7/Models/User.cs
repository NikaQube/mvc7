using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace muscshop.Models
{
    public class User
    {
        
        public int UserId { get; set; }

        [MinLength(8, ErrorMessage = "Min Lenght: 8 Symbols")]
        public string Username { get; set; }


        [MinLength(8, ErrorMessage = "Min Lenght: 8 Symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password istn't Equal")]
        public string ConfigmPassword { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; } = false;

        public Guid Confirmation { get; set; }

        public Guid PassRecovery { get; set; }

        public List<Role> Roles { get; set; }
    }
}

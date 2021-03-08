using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String  UserPassword { get; set; }
        [Required]
        public String UserRole { get; set; }

    }
}

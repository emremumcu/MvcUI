using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace MvcUI.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public SecureString Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
    }
}

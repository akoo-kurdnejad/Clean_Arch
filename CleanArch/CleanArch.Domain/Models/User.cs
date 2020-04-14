using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArch.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="UserName is Requerd...")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Requerd...")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Requerd...")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArch.Application.ViewModels
{
   public class RegisterViewModel
    {
        [Required(ErrorMessage ="UserName Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repassword Is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Is Not Equle...")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }

    public enum CheckUser
    {
        UserNameAndEmailNotValid,
        EmailNotValid,
        UserNameNotValid,
        OK
    }

}

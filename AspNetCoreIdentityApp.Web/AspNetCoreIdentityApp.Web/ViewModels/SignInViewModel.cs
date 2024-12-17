﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {
            
        }
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış")]


        [Display(Name = "Email: ")]

        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]

        [Display(Name = "Şifre:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]

        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public Boolean RememberMe { get; set; }




    }
}

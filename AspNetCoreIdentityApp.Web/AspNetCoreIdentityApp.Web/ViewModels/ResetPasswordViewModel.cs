using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ResetPasswordViewModel
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]

        [Display(Name = "Yeni Şifre:")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değil")]
        [Required(ErrorMessage = "Şifre Tekrar boş bırakılamaz")]

        [Display(Name = "Yeni Şifre Onay:")]
        public string PasswordConfirm { get; set; } = null!;


    }
}

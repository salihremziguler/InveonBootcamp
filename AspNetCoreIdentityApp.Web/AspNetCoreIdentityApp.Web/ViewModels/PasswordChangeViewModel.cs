using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]

        [Display(Name = "Eski Şifre:")]
        [MinLength(6,ErrorMessage ="Şifreniz en az 6 karakter olmalıdır.")]
        public string PasswordOld { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni Şifre boş bırakılamaz")]

        [Display(Name = "Yeni Şifre:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]

        public string PasswordNew { get; set; } = null!;
        [DataType(DataType.Password)]

        [Compare(nameof(PasswordNewConfirm), ErrorMessage = "Şifre aynı değil")]
        [Required(ErrorMessage = "Yeni Şifre Tekrar boş bırakılamaz")]

        [Display(Name = "Yeni Şifre Onay:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]

        public string PasswordNewConfirm { get; set; } = null!;

    }
}

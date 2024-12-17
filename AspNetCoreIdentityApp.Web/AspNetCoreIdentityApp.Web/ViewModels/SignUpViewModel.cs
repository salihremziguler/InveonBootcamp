using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
            
        }

        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }

        [Required(ErrorMessage ="Kullanıcı Adı boş bırakılamaz")]
        [Display(Name ="Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email formatı yanlış")]

        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon boş bırakılamaz")]

        [Display(Name ="Telefon:")]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]

        [Display (Name = "Şifre:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]

        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Compare(nameof(Password),ErrorMessage ="Şifre aynı değil")]
        [Required(ErrorMessage = "Şifre Tekrar boş bırakılamaz")]

        [Display(Name = "Şifre Onay:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")]

        public string PasswordConfirm { get; set; }



    }
}

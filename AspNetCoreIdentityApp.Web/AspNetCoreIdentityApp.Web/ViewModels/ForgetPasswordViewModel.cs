using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış")]


        [Display(Name = "Email: ")]

        public string Email { get; set; } = null!;

    }
}

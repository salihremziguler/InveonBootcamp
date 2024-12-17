using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AspNetCoreIdentityApp.Web.Localization
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"Bu {userName} daha önce bu kullanıcı tarafından alınmıştır."


            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new()
            {
                Code = "DublicateEmail",
                Description = $"Bu {email} daha önce bu kullanıcı tarafından alınmıştır."


            };
        }


        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = "Şifre 6 karakter olmalıdır"


            };
        }

    }
}

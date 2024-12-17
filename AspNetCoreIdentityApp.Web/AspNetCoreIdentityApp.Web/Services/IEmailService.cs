namespace AspNetCoreIdentityApp.Web.Services
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string resetEmaiLink, string To);

    }
}

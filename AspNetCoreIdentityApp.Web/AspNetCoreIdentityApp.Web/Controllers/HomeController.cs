using System.Diagnostics;
using System.Security.Claims;
using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityApp.Web.Extensions;
using AspNetCoreIdentityApp.Web.Services;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _logger = logger;
            _UserManager = userManager;
            _SignInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            returnUrl ??= Url.Action("Index", "Home");

            var hasUser = await _UserManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya þifre yanlýþ");
                return View();
            }



            var signInResult = await _SignInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);


            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 dakika boyunca giriþ yapamazsýnýz." });
                return View();
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { $"Email veya þifre yanlýþ", $"Baþarýsýz giriþ sayýsý = {await _UserManager.GetAccessFailedCountAsync(hasUser)}" });
                return View();
            }

            /*if (hasUser.BirthDate.HasValue)
            {
                await _SignInManager.SignInWithClaimsAsync(hasUser, model.RememberMe, new[] { new Claim("birthdate", hasUser.BirthDate.Value.ToString()) });
            }
            */

            return Redirect(returnUrl!);


        }




        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            var identityResult = await _UserManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email}, request.PasswordConfirm);

            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik Kayýt iþlemi baþarýyla gerçekleþti.";
                return RedirectToAction("SignUp");

            }


            ModelState.AddModelErrorList(identityResult.Errors.Select(x =>
            
                x.Description
            ).ToList());

           

            return View();



        }

       

     
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {

            var hasUser = await _UserManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Bu email adresine sahip kullanýcý bulunamamýþtýr.");
                return View();
            }

            string passwordResestToken = await _UserManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userId = hasUser.Id, Token = passwordResestToken }, HttpContext.Request.Scheme);
            //sample link https://localhost:7006?userId=12213&token=aajsdfjdsalkfjkdsfj

            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            TempData["SuccessMessage"] = "Þifre yenileme linki, eposta adresinize gönderilmiþtir";

            return RedirectToAction(nameof(ForgetPassword));


        }


        public IActionResult ResetPassword(string userId,string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
         


            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId=TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
            {
                throw new Exception("Bir hata meydana geldi");
            }



            var hasUser = await _UserManager.FindByIdAsync(userId.ToString()!);
            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Kulllanýcý bulunamamýþtýr.");

                return View();
            }


            var result=await _UserManager.ResetPasswordAsync(hasUser, token.ToString()!,request.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Þifreniz baþarýyla yenilenmiþtir";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            }

            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

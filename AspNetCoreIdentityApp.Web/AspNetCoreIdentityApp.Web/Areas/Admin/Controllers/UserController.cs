using AspNetCoreIdentityApp.Web.Areas.Admin.Models;
using AspNetCoreIdentityApp.Web.Extensions;
using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
   
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        public UserController(UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();

            var userViewModelList = userList.Select(x => new Models.UserViewModel()
            {
                Id = x.Id,
                Name = x.UserName,
                Email = x.Email
            }).ToList();


            return View(userViewModelList);
          
        }

        // Yeni Kullanıcı Ekleme Sayfası
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.PasswordConfirm);

            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Kullanıcı ekleme işlemi başarıyla gerçekleşti.";
                return RedirectToAction("Create");

            }


            ModelState.AddModelErrorList(identityResult.Errors.Select(x =>

                x.Description
            ).ToList());



            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                ViewData["SuccessMessage"] = "Kullanıcı bilgileri başarıyla güncellendi.";
                return View();
            }

            ModelState.AddModelErrorList(result.Errors.Select(e => e.Description).ToList());
            return View(model);
        }


  
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Silinecek rol bulunamamıştır.");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(x => x.Description).First());
            }

            TempData["SuccessMessage"] = "Kullanıcı silinmiştir";

            return RedirectToAction(nameof(UserController.UserList));




            


        }








    }
}

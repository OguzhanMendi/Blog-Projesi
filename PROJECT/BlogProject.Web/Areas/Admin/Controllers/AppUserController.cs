using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller

    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IArticleRepository articleRepository;

        public AppUserController(UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, SignInManager<IdentityUser> signInManager, IArticleRepository articleRepository)
        {
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.signInManager = signInManager;
            this.articleRepository = articleRepository;
        }
        public async Task<IActionResult> Index()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            if (appUser != null)
            {
                return View(appUser);

            }
            return Redirect("~/");

        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");  // areanın dışındaki anasayfa demiş olduk.
        }





        public IActionResult UserList()
        {


            var userList = appUserRepository.GetByDefaults
                (
                    selector: a => new UserListDTO()
                    {
                        ID = a.ID,
                        identityId = a.IdentityId,
                        ImagePath = a.ImagePath,
                        UserName = a.UserName,
                        Statu = a.Statu,

                        FullName = a.FullName,






                    },
                    expression: a => a.ID == a.ID





                );
            return View(userList);


        }


        public IActionResult Active(int id)
        {
            var x = appUserRepository.GetDefault(a => a.ID == id);
            appUserRepository.Active(x);

            return RedirectToAction("userList");

        }

        public IActionResult Delete(int id)
        {
            var x = appUserRepository.GetDefault(a => a.ID == id);
            appUserRepository.Delete(x);

            return RedirectToAction("userList");

        }


    }
}

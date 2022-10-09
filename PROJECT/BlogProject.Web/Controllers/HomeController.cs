using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.VMs;
using BlogProject.Web.Models;
using BlogProject.Web.Models.DTOs;
using BlogProject.Web.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;

        public HomeController(ILogger<HomeController> logger,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,IAppUserRepository appUserRepository, IArticleRepository articleRepository)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid) // validasyon tamamsa
            {
                IdentityUser identityUser =await  userManager.FindByEmailAsync(dto.Mail);

                if (identityUser!=null) // kullanıcı var - bu maile sahip biri var
                {
                   await  signInManager.SignOutAsync();  // içerde biri varsa cookiede silinsn
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(identityUser, dto.Password, true, true);
                    if (result.Succeeded) // şifrede doğru ise
                    {
                        var a = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
                        if (a.Statu!=Model.Enums.Statu.Passive)
                        {
                            string role = (await userManager.GetRolesAsync(identityUser)).FirstOrDefault();
                            return RedirectToAction("Index", "AppUser", new { area = role });  // localHost/member/appuser/index - KAYITLI KULLANICI ANASAYFASI
                        }
                        
                    }

                }
            }
            return View(dto);
        }






        public  IActionResult Detail(int id)
        {
           

            var y = articleRepository.GetDefault(a => a.ID == id);
            y.ViewCount += 1;
            articleRepository.Update(y);


            var a = articleRepository.GetByDefault
                (
                  selector: a => new ArticleDetailVM()
                  {

                      AppUser = a.AppUser,
                      AppUserId = a.AppUserId,
                      ID = a.ID,
                      Comments = a.Comments.Where(a => a.Statu != Model.Enums.Statu.Passive).ToList(),
                      Content = a.Content,
                      ImagePath = a.ImagePath,
                      Likes = a.Likes,
                      Title = a.Title,
                      UserArticleCategories = a.UserArticleCategories,
                      ViewCount = y.ViewCount,
                      CreatedDate=a.CreatedDate,





                  },
                      expression: a => a.ID == id,
                      include: a => a.Include(a => a.Likes).Include(a => a.AppUser).ThenInclude(a => a.Comments).Include(a => a.Comments).ThenInclude(a => a.AppUser)
                );

            return View(a);






        }



        public IActionResult ArticleLists(int id)
        {
            var list = articleRepository.GetByDefaults
               (
                   selector: a => new UserArticleListVM()
                   {
                       ImagePath = a.AppUser.ImagePath,
                       Title = a.Title,
                       Content = a.Content,
                       ArticleID = a.ID,
                       UserId = a.AppUser.ID,
                       UserFullName = a.AppUser.FullName,
                       CategoryID = id,
                       CreatedDate = a.CreatedDate,
                       CategoryName = a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList(),
                       Likes = a.Likes,
                       Comments = a.Comments.Where(a => a.Statu != Model.Enums.Statu.Passive).Take(3).ToList()
                   },
                   expression: a => a.UserArticleCategories.Any(a => a.CategoryId == id),
                   include: a => a.Include(a => a.Likes).Include(a => a.AppUser).Include(a => a.Comments).ThenInclude(a => a.AppUser).ThenInclude(a => a.Comments),
                   orderBy: a => a.OrderByDescending(a => a.CreatedDate)
               );

            return View(list.Take(20).ToList());



        }





        public IActionResult About()
        {
            return View();
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

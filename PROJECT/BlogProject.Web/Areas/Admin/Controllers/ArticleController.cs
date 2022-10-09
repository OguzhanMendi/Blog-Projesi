using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
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
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly SignInManager<IdentityUser> signInManager;

        public ArticleController(IArticleRepository articleRepository, UserManager<IdentityUser> userManager,IAppUserRepository appUserRepository,SignInManager<IdentityUser> signInManager)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ArticleList()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            var articleList = articleRepository.GetByDefaults
                (
                    selector: a => new ArticleListVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList(), 
                         Statu=a.Statu,
                           



                    },
                    expression: a => a.ID == a.ID,

                include: a => a.Include(a => a.AppUser).Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)


                );
            return View(articleList);

        }





        public IActionResult Active(int id)
        {
            var x = articleRepository.GetDefault(a => a.ID == id);
            articleRepository.Active(x);

            return  RedirectToAction("ArticleList");

        }

        public IActionResult Delete(int id)
        {
            var x = articleRepository.GetDefault(a => a.ID == id);
            articleRepository.Delete(x);
            return RedirectToAction("ArticleList");

        }





    }
}

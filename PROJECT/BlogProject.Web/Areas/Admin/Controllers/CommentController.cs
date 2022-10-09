using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Admin.Models.DTOs;
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
    public class CommentController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICommentRepository commentRepository;

        public CommentController(IAppUserRepository appUserRepository, IArticleRepository articleRepository, UserManager<IdentityUser> userManager, ICommentRepository commentRepository)
        {
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.commentRepository = commentRepository;
        }



        public async Task<IActionResult> CommentList()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


            var CommentList = commentRepository.GetByDefaults
              (
                  selector: a => new CommentListDTO()
                  {
                      AppUser = a.AppUser,
                      AppuserId = a.AppUserId,
                      Article = a.Article,
                      ArticleId = a.ArticleId,
                      ID = a.ID,
                      Text = a.Text,
                      Statu = a.Statu,
                       FullName=a.AppUser.FullName,
                        




                  },
                  expression: a => a.ID == a.ID,
                  include:a=>a.Include(a=>a.Article).ThenInclude(a=>a.AppUser)

             


              );
            return View(CommentList);


        }



        public IActionResult Active(int id)
        {
            var x = commentRepository.GetDefault(a => a.ID == id);
            commentRepository.Active(x);

            return RedirectToAction("CommentList");

        }

        public IActionResult Delete(int id)
        {
            var x = commentRepository.GetDefault(a => a.ID == id);
            commentRepository.Delete(x);

            return RedirectToAction("CommentList");

        }



    }
}

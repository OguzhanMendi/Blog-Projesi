using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Member.Models.DTOs;
using BlogProject.Web.Areas.Member.Models.VMs;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly ICommentRepository commentRepository;
        private readonly ILikeRepository likeRepository;

        public CommentController(IAppUserRepository appUserRepository, IArticleRepository articleRepository, UserManager<IdentityUser> userManager, IMapper mapper, ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.mapper = mapper;
            this.commentRepository = commentRepository;
            this.likeRepository = likeRepository;
        }



        public async Task<IActionResult> Create(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            var y = articleRepository.GetDefault(a => a.ID == id);
            y.ViewCount += 1;
            articleRepository.Update(y);


            var a = articleRepository.GetByDefault
                (
                  selector: a => new CreateCommentVM()
                  {

                      AppUser = a.AppUser,
                      AppUserId = appUser.ID,
                      ID = a.ID,
                      Comments = a.Comments.Where(a => a.Statu != Model.Enums.Statu.Passive).ToList(),
                      Content = a.Content,
                      ImagePath = a.ImagePath,
                      Likes = a.Likes,
                      Title = a.Title,
                       CreatedDate=a.CreatedDate,
                      UserArticleCategories = a.UserArticleCategories,
                      ViewCount = y.ViewCount,
                      //ModelId = appUser.ID, 
                      ArticleId = a.ID,




                  },
                      expression: a => a.ID == id,
                      include: a => a.Include(a => a.Likes).Include(a => a.AppUser).Include(a => a.Comments).ThenInclude(a => a.AppUser).ThenInclude(a => a.Comments)
                );

            return View(a);


        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentVM vm)
        {
            if (ModelState.IsValid)
            {

                IdentityUser identityUser = await userManager.GetUserAsync(User);
                AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


                Comment comment = new Comment();
                comment.Text = vm.Text;
                comment.AppUserId = vm.ModelId;
                comment.AppUser = appUser;
                comment.ArticleId = vm.ID;





                commentRepository.Create(comment);
            }


            return RedirectToAction("Create", new { vm.ID });

        }




        [HttpPost]
        public IActionResult Update(CreateCommentVM vm, int id)
        {
            if (ModelState.IsValid)
            {
                var x = commentRepository.GetDefault(a => a.ID == id);
                x.Text = vm.Text;
                commentRepository.Update(x);
              
              

            }
            id = vm.ArticleId;
            return RedirectToAction("Create", new { id });

        }













        public IActionResult Delete(int id, CreateCommentVM vm)
        {
            Comment comment = commentRepository.GetDefault(a => a.ID == id);
            commentRepository.Delete(comment);
            return RedirectToAction("Index", "AppUser");

            //return RedirectToAction("Index");



        }




        public async Task<IActionResult> Like(int id)
        {

            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Article article = articleRepository.GetDefault(a => a.ID == id);
            article.Likes.Add(new Like { AppUser = appUser, AppUserId = appUser.ID, Article = article, ArticleId = article.ID });


            articleRepository.Update(article);
            return RedirectToAction("Create", new { id });
        }

        public async Task<IActionResult> UnLike(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Article article = articleRepository.GetDefault(a => a.ID == id);
            Like like = articleRepository.GetByDefault
                (
                  selector: a => new Like { AppUser = appUser, AppUserId = appUser.ID, Article = article, ArticleId = article.ID },
                  expression: a => a.Statu != Statu.Passive, include: a => a.Include(a => a.Likes).ThenInclude(a => a.Article).Include(a => a.Likes).ThenInclude(a => a.AppUser)
                );
            likeRepository.Delete(like);
            return RedirectToAction("Create", new { id });
        }

    }

}


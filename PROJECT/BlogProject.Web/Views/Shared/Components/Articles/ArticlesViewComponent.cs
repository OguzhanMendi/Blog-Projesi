using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Views.Shared.Components.Articles
{
    [ViewComponent(Name = "Articles")]
    public class ArticlesViewComponent : ViewComponent
    {
        private readonly IArticleRepository articleRepository;

        //bu componntte en güncel yazılan 10 makaleyi basalım.

        public ArticlesViewComponent(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public IViewComponentResult Invoke()
        {
            var list = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleForComponentDTO()
                    {
                          ImagePath=a.AppUser.ImagePath,
                        Title = a.Title,
                        Content = a.Content,
                        ArticleID = a.ID,
                        UserId = a.AppUser.ID,
                        UserFullName = a.AppUser.FullName,
                        Image = a.ImagePath,
                        CreatedDate = a.CreatedDate,
                        CategoryName =a.UserArticleCategories.Where(a=>a.Category.ID==a.Category.ID).Select(a=>a.Category.Name).ToList(),
                         Likes=a.Likes,
                          Comments=a.Comments.Where(a=>a.Statu!= Model.Enums.Statu.Passive).Take(3).ToList()
                    },
                    expression: a => a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).ThenInclude(a=>a.Articles).ThenInclude(a=>a.UserArticleCategories).Include(a=>a.Comments).Include(a=>a.UserArticleCategories),
                    orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                );

            return View(list.Take(10).ToList());

        }

    }
}

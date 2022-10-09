using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Views.Shared.Components.AppUser
{
    [ViewComponent(Name = "AllCategory")]
    public class AllCategory : ViewComponent
    {
        private IArticleRepository articleRepository;
        private IAppUserRepository appUserRepository;
        private readonly ICategoryRepository categoryRepository;
        public AllCategory(IArticleRepository articleRepository, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.appUserRepository = appUserRepository;
            this.categoryRepository = categoryRepository;
        }



        public IViewComponentResult Invoke()
        {

            var allCategory = categoryRepository.GetByDefaults
               (
                 selector: a => new CategoryComponentDTO() { ID = a.ID, Name = a.Name },
                 expression: a => a.Statu != Model.Enums.Statu.Passive,
                 include: a => a.Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)

               );

            return View(allCategory);

        }



    }
}

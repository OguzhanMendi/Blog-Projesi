using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Views.Shared.Components.Category
{
    [ViewComponent(Name = "AlCategory")]
    public class AlCategory : ViewComponent
    {
      
      
        
            private IArticleRepository articleRepository;
            private IAppUserRepository appUserRepository;
            private readonly ICategoryRepository categoryRepository;
            public AlCategory(IArticleRepository articleRepository, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository)
            {
                this.articleRepository = articleRepository;
                this.appUserRepository = appUserRepository;
                this.categoryRepository = categoryRepository;
            }



            public IViewComponentResult Invoke()
            {

                var allCategory = categoryRepository.GetByDefaults
                   (
                     selector: a => new AlCategoryDTO() { ID = a.ID, Name = a.Name },
                     expression: a => a.Statu != Model.Enums.Statu.Passive,
                     include: a => a.Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)

                   );

                return View(allCategory);

            }



        }
    }


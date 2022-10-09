using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(IAppUserRepository appUserRepository, ICategoryRepository categoryRepository )
        {
            this.appUserRepository = appUserRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task< IActionResult> CategoryList()
        {
          

            var category = categoryRepository.GetByDefaults
                (
                  selector: a => new AllCategoryListDTO
                  {
                     
                      ID = a.ID,
                      Description = a.Description,
                      Name = a.Name,
                       Statu=a.Statu,
                        



                  },
                  expression: a => a.ID==a.ID
                );
            return View(category);


        }


        public IActionResult Active(int id)
        {
            var x = categoryRepository.GetDefault(a => a.ID == id);
            categoryRepository.Active(x);

            return RedirectToAction("CategoryList");

        }

        public IActionResult Delete(int id)
        {
            var x = categoryRepository.GetDefault(a => a.ID == id);
            categoryRepository.Delete(x);

            return RedirectToAction("CategoryList");

        }


    }
}

using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogProject.Web.Areas.Member.Models.VMs;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IUserFollowCategoryRepository userFollowCategoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, IUserFollowCategoryRepository userFollowCategoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.userFollowCategoryRepository = userFollowCategoryRepository;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid) // validasyon tamamsa 
            {
                //Category category = new Category();
                //category.Name = dto.Name;
                //category.Description = dto.Description;

                var category = mapper.Map<Category>(dto);
                categoryRepository.Create(category);
                return RedirectToAction("List");

            }
            return View(dto);
        }

        public async Task<IActionResult> List()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            var category = categoryRepository.GetByDefaults
                (
                  selector: a => new CategoryListDTO
                  {
                      AppUserId =appUser.ID,
                      ID = a.ID,
                      Description = a.Description,
                      Name = a.Name,
                      UserFollowCategories=a.UserFollowCategories.Where(a=>a.AppUser.ID==appUser.ID).ToList()
                     
                      

                  },
                  expression:a=>a.Statu!=Statu.Passive
                );
            return View(category);
        }

        public IActionResult Detail(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            return View(category);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id); // id le tuttum
            var categoryMapper = mapper.Map<UpdateCategoryDTO>(category);   // mapledim ki gelsin        
            return View(categoryMapper);

        }


        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO dto)
        {

            if (ModelState.IsValid)
            {
                var categoryMapper = mapper.Map<Category>(dto);  // Dto dan değiştirip gelen şeyleri tekrar mapledim.            
                categoryRepository.Update(categoryMapper);     // tuttuğum İD değşştirdim.
                return RedirectToAction("List");

            }
            return View(dto);
        }


        // Delete İşlemi 
        public IActionResult Delete(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id); // İD sinden tuttum
            categoryRepository.Delete(category); // Delete metodu içinde Kendisi Passive Aldı.
            return RedirectToAction("List");

        }


        //toDo: bu controllerın detay,sil,guncellesi sizdedir.

        //TODO: kullanıcı bir kategoriyi takip ediyoersa TAKİBİ BIRAK , etmiyorsa TAKİP ET yazmalı List yapıısnın viewında :)
        public async Task<IActionResult> Follow(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            Category category = categoryRepository.GetDefault(a => a.ID == id);

            category.UserFollowCategories.Add(new UserFollowCategory { Category = category, CategoryId = category.ID, AppUser = appUser, AppUserId = appUser.ID });

            categoryRepository.Update(category);
            return RedirectToAction("List");
        }




        // UN FOLLOWSSSS :DD

        public async Task<IActionResult> UnFollow(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


            Category category = categoryRepository.GetDefault(a => a.ID == id);


            UserFollowCategory userFollowCategory = categoryRepository.GetByDefault(selector: a => new UserFollowCategory() { AppUser = appUser, AppUserId = appUser.ID, Category = category, CategoryId = category.ID }, expression: a => a.Statu != Statu.Passive, include: a => a.Include(a => a.UserFollowCategories).ThenInclude(a => a.Category).Include(a => a.UserFollowCategories).ThenInclude(a => a.AppUser));

            userFollowCategoryRepository.Delete(userFollowCategory);

            return RedirectToAction("List");



        }



    }

}

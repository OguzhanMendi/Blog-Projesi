using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using BlogProject.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        private readonly IUserArticleCategoryRepository userArticleCategoryRepository;

        public ArticleController(IArticleRepository articleRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository, IMapper mapper, IUserArticleCategoryRepository userArticleCategoryRepository)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.userArticleCategoryRepository = userArticleCategoryRepository;
        }


        public async Task<IActionResult> Create()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            CreateArticleVM vm = new CreateArticleVM()
            {
                Categories = categoryRepository.GetByDefaults
                (
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name, IsSelect = false },
                    expression: a => a.Statu != Model.Enums.Statu.Passive
                 ),
                AppUserID = appUser.ID
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleVM vm)
        {


            if (ModelState.IsValid)
            {

                if (vm.Categories.Any(a => a.IsSelect)) // gelen kategoriler SEÇİLİ İSE GİR
                {

                    var article = mapper.Map<Article>(vm);

                    using var image = Image.Load(vm.Image.OpenReadStream()); // dosyayı oku al
                    image.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                    Guid guid = Guid.NewGuid();

                    image.Save($"wwwroot/images/{guid}.jpg");  // dosyayı images altına kaydet
                    article.ImagePath = $"/images/{guid}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.
                   



                    {
                        foreach (GetCategoryDTO item in vm.Categories.Where(a => a.IsSelect))
                        {



                            var UserArticleCategory = mapper.Map<UserArticleCategory>(item);

                            article.UserArticleCategories.Add(new UserArticleCategory { Article = article, ArticleId = article.ID, Category = UserArticleCategory.Category, CategoryId = item.ID });






                        }

                    }

                    articleRepository.Create(article);
                    return RedirectToAction("List");
                }
                ViewBag.IsFailied = true;
                return RedirectToAction("Create");





            }
            else  // Her sayfa yenilendiğinde veya Validlasyon yanlış olunca tekrar getiricek 
            {
                IdentityUser identityUser = await userManager.GetUserAsync(User);
                AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
                CreateArticleVM Articlevm = new CreateArticleVM()
                {
                    Categories = categoryRepository.GetByDefaults
                 (
                     selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                     expression: a => a.Statu != Model.Enums.Statu.Passive

                  ),
                    AppUserID = appUser.ID
                };
                return View(Articlevm);
            }



        }



        public async Task<IActionResult> List()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            // cookide olan kşinin kendi makalelerini çekeceğimiz için önce kişyi yakaladık.


            var articleList = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList()



                    },
                    expression: a => a.AppUserId == appUser.ID && a.Statu != Model.Enums.Statu.Passive,

                include: a => a.Include(a => a.AppUser).Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)


                ); ; ; ;
            return View(articleList);

        }

        public IActionResult Detail(int id)
        {

            Article article = articleRepository.GetDefault(a => a.ID == id);
            var articleList = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                         AppUser=a.AppUser,
                        CategoryName = a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList()
                         


                    },
                    expression: a => a.ID == article.ID && a.Statu != Model.Enums.Statu.Passive,

                include: a => a.Include(a => a.AppUser).Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)
                );
            return View(articleList);


        }




        public IActionResult Update(int id)
        {


            //bütün categoryler getirdik.
            var allCategory = categoryRepository.GetByDefaults
                (
                  selector: a => new GetCategoryDTO() { ID = a.ID, Name = a.Name /*IsSelect = false*/ },
                  expression: a => a.Statu != Model.Enums.Statu.Passive

                );

            // Seçili Categoryleri getiricez.

            var checkedCategory = userArticleCategoryRepository.GetByDefaults
              (
                 selector: a => new CheckedCategoryDTO() { ID = a.CategoryId, Name = a.Category.Name, IsSelect = true },
                 expression: a => a.Article.ID == id

          ); ;


            for (int i = 0; i < allCategory.Count; i++)
            {
                for (int a = 0; a < checkedCategory.Count; a++)
                {
                    if (allCategory[i].ID == checkedCategory[a].ID)
                    {
                        allCategory[i].IsSelect = true;
                    }
                }
            }


            var articleList = articleRepository.GetByDefault
                (
                   selector: a => new UpdateArticleVM()
                   {
                       ID = a.ID,
                       Title = a.Title,
                       Content = a.Content,
                       ImagePath = a.ImagePath,
                       CategoryDTOs = allCategory,
                       AppUserID = a.AppUser.ID,


                   },
                   expression: a => a.ID == id,
                   include: a => a.Include(a => a.AppUser).Include(a => a.UserArticleCategories).ThenInclude(a => a.Category)



                );
            return View(articleList);

        }

        [HttpPost]
        public IActionResult Update(UpdateArticleVM vm)
        {


            if (ModelState.IsValid)
            {

                if (vm.Image != null)//eğer yeni resim eklemişse buraya girmeli eski resmi bilup silmeli ve yeni resmi eklemeli veri
                                     //veri tabanındaki resmin idsi yeni resme gelmeli veya veritabanındaki resmin idside silinip yeni id atanmalı
                {
                    FileSystem.DeleteFile($"wwwroot{vm.ImagePath}");//var olan resmi silmesini bekliyorum
                    using var image = Image.Load(vm.Image.OpenReadStream()); // dosyayı oku al                    
                    image.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                    Guid guid = Guid.NewGuid();
                    image.Save($"wwwroot/images/{guid}.jpg");  // dosyayı images altına kaydet
                    vm.ImagePath = $"/images/{guid}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.

                }
                var article = mapper.Map<Article>(vm);
                articleRepository.Update(article);

                var allCategory = userArticleCategoryRepository.GetByDefaults
                     (
                     selector: a => new ArticleCategoryDTO { ArticleId = a.ArticleId, CategoryId = a.CategoryId },
                     expression: a => a.ArticleId == vm.ID
                     );
                //önce aratoblodaki tüm articleidleri eşit olanları silelim
                foreach (var item in allCategory)
                {
                    ArticleCategoryDTO articleCategoriDto = new ArticleCategoryDTO();
                    articleCategoriDto.CategoryId = item.CategoryId;
                    articleCategoriDto.ArticleId = item.ArticleId;
                    UserArticleCategory Map = mapper.Map<UserArticleCategory>(articleCategoriDto);
                    userArticleCategoryRepository.Delete(Map);

                }
                //articlelistdeki catagorilerden seçili olanları eklicem

                foreach (GetCategoryDTO item in vm.CategoryDTOs.Where(a => a.IsSelect))
                {
                    ArticleCategoryDTO articleCategoryDTO = new ArticleCategoryDTO();
                    articleCategoryDTO.ArticleId = vm.ID;
                    articleCategoryDTO.CategoryId = item.ID;
                    var Map = mapper.Map<UserArticleCategory>(articleCategoryDTO);
                    userArticleCategoryRepository.Create(Map);
                }

                return RedirectToAction("List");
            }

            return View(vm);





        }

        // DELETE İŞLEMİİ!!

        public IActionResult Delete(int id)
        {
            Article article = articleRepository.GetDefault(a => a.ID == id);
            articleRepository.Delete(article);
            return RedirectToAction("List");

        }




        // MAKALE LİSTELEME

        public IActionResult ArticleList(int id)
        {
            var list = articleRepository.GetByDefaults
               (
                   selector: a => new ArticleListVM()
                   {
                       ImagePath = a.AppUser.ImagePath,
                       Title = a.Title,
                       Content = a.Content,
                       ArticleID = a.ID,
                       UserId = a.AppUser.ID,
                        AppUser=a.AppUser,
                       UserFullName = a.AppUser.FullName,
                       CategoryID=id,
                       CreatedDate = a.CreatedDate,
                       CategoryName = a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList(),
                       Likes = a.Likes,
                       Comments = a.Comments.Where(a => a.Statu != Model.Enums.Statu.Passive).Take(3).ToList()
                   },
                   expression: a =>a.UserArticleCategories.Any(a=>a.CategoryId==id),
                   include: a => a.Include(a => a.Likes).Include(a => a.AppUser).Include(a => a.Comments).ThenInclude(a => a.AppUser).ThenInclude(a => a.Comments),
                   orderBy: a => a.OrderByDescending(a => a.CreatedDate)
               );

            return View(list.Take(20).ToList());



        }



    }
}


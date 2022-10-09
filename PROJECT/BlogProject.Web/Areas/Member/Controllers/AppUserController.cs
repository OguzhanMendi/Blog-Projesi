using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using BlogProject.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IMapper mapper;
        private readonly IUserPasswordRepository userPasswordRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;

        public AppUserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAppUserRepository appUserRepository, IMapper mapper, IUserPasswordRepository userPasswordRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserRepository = appUserRepository;
            this.mapper = mapper;
            this.userPasswordRepository = userPasswordRepository;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }


        public async Task<IActionResult> Index()
        {
            // identity user kişisi
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            if (appUser != null)
            {

                var article = articleRepository.GetByDefaults
                    (
                      selector: a => new AllArticleVM
                      {
                          ID = a.ID,

                          AppUser = a.AppUser,
                          AppUserId = a.AppUser.ID,
                          Content = a.Content,
                          ImagePath = a.ImagePath,
                          Likes = a.Likes,
                           CreatedDate=a.CreatedDate,
                          Title = a.Title,
                          Comments = a.Comments.Where(a => a.Statu != Model.Enums.Statu.Passive).Take(3).ToList(),
                           CategoryName= a.UserArticleCategories.Where(a => a.Category.ID == a.Category.ID).Select(a => a.Category.Name).ToList(),



                      },
                      expression: a => a.Statu != Model.Enums.Statu.Passive,
                      include: a => a.Include(a => a.AppUser).Include(a => a.Likes).Include(a => a.UserArticleCategories).Include(a => a.Comments)


                    ); ;

                return View(article);






            }
            // return RedirectToAction("Index","Home"); // globaldeki home-index yani anasayfa
            return Redirect("~/");  // areasız başlangıç sayfasına yani home- index
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");  // areanın dışındaki anasayfa demiş olduk.
        }




        public async Task<IActionResult> Update()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);



            var user = appUserRepository.GetByDefault
               (
                 selector: a => new UpdateAppUserDTO()
                 {
                     ID = appUser.ID,
                     //Mail = identityUser.Email,
                     FirstName = appUser.FirstName,
                     LastName = appUser.LastName,
                     Password = appUser.Password,

                     ImagePath = appUser.ImagePath,
                     UserName = appUser.UserName,
                     IdentityId = appUser.IdentityId

                 },
                 expression: a => a.Statu != Model.Enums.Statu.Passive


               ); ; ; ;

            return View(user); ;
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateAppUserDTO dto)
        {

            if (ModelState.IsValid)
            {

                IdentityUser identityUser = await userManager.GetUserAsync(User);
                //AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


                if (dto.Image != null)//eğer yeni resim eklemişse buraya girmeli eski resmi bilup silmeli ve yeni resmi eklemeli veri
                                      //veri tabanındaki resmin idsi yeni resme gelmeli veya veritabanındaki resmin idside silinip yeni id atanmalı
                {
                    FileSystem.DeleteFile($"wwwroot{dto.ImagePath}");//var olan resmi silmesini bekliyorum
                    using var image = Image.Load(dto.Image.OpenReadStream()); // dosyayı oku al                    
                    image.Mutate(a => a.Resize(80, 80));
                    Guid guid = Guid.NewGuid();
                    image.Save($"wwwroot/images/{guid}.jpg");
                    dto.ImagePath = $"/images/{guid}.jpg";

                }



                //identityUser.Email = dto.Mail;  // dtodaki mail ile mail eşitledim.
                //identityUser.NormalizedEmail = dto.Mail.ToUpper();



                // UserPasswords

                var Map = mapper.Map<AppUser>(dto);
                appUserRepository.Update(Map);
                await signInManager.SignOutAsync();
                return Redirect("~/");

            }
            return View(dto);



        }





        [HttpGet]

        public async Task<IActionResult> UpdatePwd()
        {

            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);



            var user = appUserRepository.GetByDefault
               (
                 selector: a => new UpdatePwdDTO()
                 {
                     ID = appUser.ID,
                     //FirstName = appUser.FirstName,
                     //LastName = appUser.LastName,
                     //UserName = appUser.UserName,
                     //Image = appUser.Image,
                     //ImagePath = appUser.ImagePath,


                     IdentityId = appUser.IdentityId


                 },
                 expression: a => a.IdentityId == identityUser.Id


               ); ; ;

            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePwd(UpdatePwdDTO dto)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await userManager.GetUserAsync(User);


                AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
                //ID ye bağlı şifreleri getirdim.
                var userpwds = userPasswordRepository.GetByDefaults
               (
                     selector: a => new ListPasswordDTO() { ID = a.AppUser.ID, Password = a.Password },
                      expression: a => a.AppUser.ID == dto.ID,
                     orderBy: a => a.Take(3).OrderByDescending(a => a.CreatedDate)
               ); ;
                if (userpwds.All(a => a.Password != dto.Password))  // dto dan gelen pw ile ara tablodaki pwler aynı mı?
                {
                    ViewBag.IsSuccess = true;

                    identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, dto.Password);
                    //await userManager.ChangePasswordAsync(identityUser, dto.Password, dto.CurrentPassword);


                    UserPassword userPassword = new UserPassword { AppUserId = dto.ID, Password = dto.Password }; // tabloyu kaldırdım.
                    userPasswordRepository.Create(userPassword); // ara tabloya kaydettim.
                    appUser.Password = dto.Password;
                    //var Map = mapper.Map<AppUser>(dto);
                    appUserRepository.Update(appUser);

                }
                else
                {
                    ViewBag.IsFailied = true;
                }

            }

            return View(dto);
        }


        public async Task<IActionResult> UpdateMail()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            var user = appUserRepository.GetByDefault
            (
              selector: a => new UpdateMailDTO()
              {
                  ID = appUser.ID,

                  Mail = identityUser.Email,

                  IdentityId = appUser.IdentityId


              },
              expression: a => a.IdentityId == identityUser.Id



            ); ; ;

            return View(user);


        }


        [HttpPost]
        public async Task<IActionResult> UpdateMail(UpdateMailDTO dto)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            if (ModelState.IsValid)
            {

                //identityUser.Email = dto.Mail;  // dtodaki mail ile mail eşitledim.
                //identityUser.NormalizedEmail = dto.Mail.ToUpper();
                identityUser.Email = dto.Mail;


                var result = await userManager.UpdateAsync(identityUser);

                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsFailied = true;
            }
            return View(dto);




        }

        public IActionResult Detail(int id)
        {


            AppUser appUser = appUserRepository.GetDefault(a => a.ID == id);
            return View(appUser);







        }



        public async Task<IActionResult> Delete()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            appUserRepository.Delete(appUser);
            await signInManager.SignOutAsync();
            return Redirect("~/");


        }


        // Eşsiz Mail Validlasyon...
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> Use(string Mail)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            var user = await userManager.FindByEmailAsync(Mail);
            if (user == null || user.Email == identityUser.Email)
            {
                return Json(true);
            }
            else
            {

                return Json($"Email {Mail} zaten Kullanılıyor...!");
            }
        }







        public IActionResult About()
        {
            return View();
        }







    }
}


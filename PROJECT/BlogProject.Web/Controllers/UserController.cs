using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly IAppUserRepository appUserRepository;
        private readonly IUserPasswordRepository userPasswordRepository;

        public UserController(UserManager<IdentityUser> userManager,IMapper mapper,IAppUserRepository appUserRepository, IUserPasswordRepository userPasswordRepository)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
            this.userPasswordRepository = userPasswordRepository;
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            if (ModelState.IsValid) // validasyonlar tamamsa
            {
                string newId = Guid.NewGuid().ToString();
                IdentityUser identityUser = new IdentityUser { Email = dto.Mail, UserName = dto.UserName, Id = newId };

                IdentityResult result =await userManager.CreateAsync(identityUser,dto.Password);
                if (result.Succeeded) // identity tarafında kişi oluşmuşsa
                {
                  await  userManager.AddToRoleAsync(identityUser,"Member");

                    //AppUser appUser = new AppUser();
                    //appUser.FirstName = dto.FirstName;
                    //appUser.LastName = dto.LastName;


                    var user = mapper.Map<AppUser>(dto);
                    
                    user.IdentityId = newId;  // identity kişisi ile appUser kişisini bağladık.
                 

                    using var image = Image.Load(dto.Image.OpenReadStream()); // dosyayı oku al
                    image.Mutate(a=>a.Resize(80,80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                    image.Save($"wwwroot/images/{user.UserName}.jpg");  // dosyayı images altına kaydet
                    user.ImagePath = $"/images/{user.UserName}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.

                    appUserRepository.Create(user);

                    // UserPasswords
                    UserPassword userPassword = new UserPassword { AppUserId = user.ID, Password = user.Password,CreatedDate=user.CreatedDate}; // tabloyu kaldırdım.
                    userPasswordRepository.Create(userPassword); // ara tabloya kaydettim.
                    return RedirectToAction("Login", "Home");



                }
            }
            return View(dto);
        }


        public IActionResult Detail(int id)
        {


            AppUser appUser = appUserRepository.GetDefault(a => a.ID == id);
            return View(appUser);







        }




        // Mail Eşsiz Olması için kayıtlı mail bir daha kayıt olamaz
        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsMailUse(string Mail)       
        {
                var user =  await userManager.FindByEmailAsync(Mail);  
            if (user==null)
            {
                return Json(true);
            } 
            else
            {

                return Json($"Email {Mail} zaten Kullanılıyor...!");
            }
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserNameUse(string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return Json(true);
            }
            else
            {

                return Json($"UserName {UserName} Zaten Kullanılıyor... ");
            }
        }


    }
}

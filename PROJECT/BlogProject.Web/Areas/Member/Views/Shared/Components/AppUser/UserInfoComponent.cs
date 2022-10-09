using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Views.Shared.Components.AppUser
{
    [ViewComponent(Name = "AppUser")]
    public class UserInfoComponent: ViewComponent
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly UserManager<IdentityUser> userManager;

        public UserInfoComponent(IAppUserRepository appUserRepository, UserManager<IdentityUser> userManager)
        {
            this.appUserRepository = appUserRepository;
            this.userManager = userManager;
        }



        public   IViewComponentResult Invoke()
        {
         

            var userComponent = appUserRepository.GetByDefault
                (
                  selector: a => new UserComponentDTO()
                  {
                      ID=a.ID,
                      FirstName = a.FirstName,
                      LastName = a.LastName,
                      ImagePath = a.ImagePath,

                  },
                  expression: a => a.UserName==User.Identity.Name      // identity kimlikeri Eşitle

                );
            return View (userComponent);
        }


    }
}

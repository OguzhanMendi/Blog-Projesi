using AutoMapper;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using BlogProject.Web.Areas.Member.Models.VMs;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.Mappers
{
    public class Mapping : Profile
    {

        // mapper kütüphanesiin yapmasını istediğimiz mapleme işlemlerini tek tek burada söylememiz gerekiyor.

        // bu sınıfı oluşturdul çünkü startUpda bize mapleme işlemlerini nerede yapıyorsun diye soracaktı.

        public Mapping()
        {
            CreateMap<CreateUserDTO, AppUser>().ReverseMap(); // reverseMap : mapleme işlemini iki yönlü çalıştır.
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateArticleVM, Article>();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<CreateArticleVM, UserArticleCategory>().ReverseMap();
            CreateMap<GetCategoryDTO, UserArticleCategory>().ReverseMap();
            CreateMap<UpdateArticleVM, Article>().ReverseMap();
            CreateMap<ArticleCategoryDTO, UserArticleCategory>().ReverseMap();
            CreateMap<UpdateAppUserDTO, AppUser>().ReverseMap();
            CreateMap<UpdateAppUserDTO, IdentityUser>().ReverseMap();
            CreateMap<UpdatePwdDTO, AppUser>().ReverseMap();
          
        



        }


    }
}

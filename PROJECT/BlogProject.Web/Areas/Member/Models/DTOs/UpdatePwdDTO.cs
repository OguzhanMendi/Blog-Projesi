using BlogProject.Model.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class UpdatePwdDTO
    {

        public int ID { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Mevcut Şifre")]
        //public string CurrentPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
       
        [MinLength(4), MaxLength(100)]
        public  string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "  Tekrar Yeni Şifre")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Olmak Zorunda..")]
        public string ConfirmPassword { get; set; }

        public string IdentityId { get; set; }






    }
}

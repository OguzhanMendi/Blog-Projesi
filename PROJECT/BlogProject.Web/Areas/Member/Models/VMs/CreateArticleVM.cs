using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class CreateArticleVM
    {
        // article

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string Content { get; set; }




        public string ImagePath { get; set; } // bu kayıttan sonra dolacak - boş bırakılmaz diyemeyiz !

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public IFormFile Image { get; set; }

        // category

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int CategoryID { get; set; }

        public List<GetCategoryDTO> Categories { get; set; }


        // USER

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int AppUserID { get; set; }


       

    }

}

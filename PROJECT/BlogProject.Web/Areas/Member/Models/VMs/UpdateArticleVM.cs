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
    public class UpdateArticleVM
    {

        public int ID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string Content { get; set; }


        public string ImagePath { get; set; }



        public IFormFile Image { get; set; }


         
        public List<GetCategoryDTO> CategoryDTOs { get; set; }

        public int AppUserID { get; set; }




        // DENEME 1



    }
}

using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class GetArticleVM
    {
        // LİST actionında kullanacağım propları toparlamak amacıyla kullandım.

        public int ArticleID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string UserFullName { get; set; }  // appUser

        public AppUser AppUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string> CategoryName { get; set; }



        // DENEME 1



    }
}

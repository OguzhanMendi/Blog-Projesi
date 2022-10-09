using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class AllArticleVM
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }


        public List<string> CategoryName { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<UserArticleCategory> UserArticleCategories { get; set; }


       
        public List<Comment> Comments { get; set; }

      
        public List<Like> Likes { get; set; }


    }
}

using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.VMs
{
    public class ArticleDetailVM
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }


        public DateTime CreatedDate { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // 1 yorum 1 makaleye aittir.

        public int ModelId { get; set; }



        public List<UserArticleCategory> UserArticleCategories { get; set; }


        public string Text { get; set; }



        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }


        public int ViewCount { get; set; }



    }
}

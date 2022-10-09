using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.VMs
{
    public class UserArticleListVM
    {

        public string Title { get; set; }
        public string Content { get; set; }
        //public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }


        public string Image { get; set; }
        public string UserFullName { get; set; }

        public string ImagePath { get; set; }
        public int UserId { get; set; } // eğer bu yapıdan yazarı profil sayfasına gitmek istersek id biilgisini tutmalıyız.

        public int ArticleID { get; set; } // Eğer bu yapıdan makalenin tümünü okumak için detay sayfasına gitmek istersek makale id de tutulmalı.
        public int CategoryID { get; set; } // Eğer bu yapıdan makalenin tümünü okumak için detay sayfasına gitmek istersek makale id de tutulmalı.


        public List<string> CategoryName { get; set; }


        public List<UserArticleCategory> UserArticleCategory { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

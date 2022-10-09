using BlogProject.Model.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Model.Entities.Concrete
{
    public class Article :BaseEntity
    {
        public Article()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            UserArticleCategories = new List<UserArticleCategory>();


        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }  // dosya yolunu tutacak

        [NotMapped]
        public IFormFile Image { get; set; } // dosyayı okuyup,kaydedecek.

        //naviigation Property

        // 1 makalenin 1 oluşturucusu
        public int AppUserId { get; set; }

        public AppUser  AppUser { get; set; }

        // 1 makalenin 1 kategorisi
        //public int CategoryId { get; set; }
        //public Category  Category { get; set; }

        // çok makalenin çok kategorisi

        public   List<UserArticleCategory> UserArticleCategories  { get; set; }


        // 1 makalenin çokça yorumu
        public List<Comment>  Comments { get; set; }

        // 1 makalenin çokça beğenisi
        public List<Like> Likes { get; set; }


        public int ViewCount { get; set; } = 0;


    }
}
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class CategoryListDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }


        public int AppUserId { get; set; }

        public List<UserFollowCategory> UserFollowCategories { get; set; }




        

    }
}

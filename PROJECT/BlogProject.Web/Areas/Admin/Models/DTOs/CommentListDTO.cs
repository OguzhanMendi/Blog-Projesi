using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CommentListDTO
    {

        public int ID { get; set; }
        public AppUser AppUser { get; set; }
        public int AppuserId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public string Text { get; set; }
        public string FullName { get; set; }


        private Statu _status = Statu.Active;

        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

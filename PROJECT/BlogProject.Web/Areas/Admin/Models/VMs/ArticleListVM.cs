using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class ArticleListVM
    {

        public int ArticleID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string UserFullName { get; set; }  // appUser


        private Statu _status = Statu.Active;

        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }

        public List<string> CategoryName { get; set; }



        // DENEME 1
    }
}

using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class AllCategoryListDTO
    {

        public int ID { get; set; }
        public string Description { get; set; }


        public int AppUserId { get; set; }
        public string Name { get; set; }

        private Statu _status = Statu.Active;

        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}

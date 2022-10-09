using BlogProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class UserListDTO
    {
        public int ID { get; set; }

        public string identityId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

        public string ImagePath { get; set; }


        public string Mail { get; set; }



        private Statu _status = Statu.Active;

        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}

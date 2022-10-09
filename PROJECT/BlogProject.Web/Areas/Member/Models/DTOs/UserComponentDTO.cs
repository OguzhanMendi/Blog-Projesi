using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class UserComponentDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
                  
        public string ImagePath { get; set; }

        public string FullName => FirstName + " " + LastName;
        public IFormFile Image { get; set; }

    }
}

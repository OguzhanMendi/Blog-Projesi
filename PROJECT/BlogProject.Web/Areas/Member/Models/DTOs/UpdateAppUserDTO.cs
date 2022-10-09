using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class UpdateAppUserDTO
    {
     ///*   [Remote(action: "Use", controller: "AppUser")]  */ // Sorgu 
     //   [Required(ErrorMessage = "alan boş bırakılamaz")]
     //   [DataType(DataType.EmailAddress)]
     //   public string Mail { get; set; }
        public int ID { get; set; }
        public string IdentityId { get; set; }



        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string LastName { get; set; }

        public string UserName { get; set; }  // Runtime AppUser patlamasın

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


     
        public string ImagePath { get; set; }


        public IFormFile Image { get; set; }

       
    }
}

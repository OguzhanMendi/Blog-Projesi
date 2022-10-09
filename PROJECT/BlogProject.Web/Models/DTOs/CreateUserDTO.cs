using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage ="alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string LastName { get; set; }
        [Remote(action: "IsUserNameUse", controller: "User")] // Sorgu 
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public IFormFile Image { get; set; }


        [Remote(action: "IsMailUse",controller:"User")]   // Sorgu 
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
    
        public string Mail { get; set; }


    }
}

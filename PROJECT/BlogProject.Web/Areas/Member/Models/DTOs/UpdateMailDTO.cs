using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class UpdateMailDTO
    {

        [Remote(action: "Use", controller: "AppUser")]   // Sorgu 
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


        public int ID { get; set; }
        public string IdentityId { get; set; }

    }
}

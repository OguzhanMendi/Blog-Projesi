using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage ="Bu alan bş bırakılamaz!")]
        [MinLength(2),MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string Description { get; set; }
    }
}

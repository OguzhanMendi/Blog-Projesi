using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class CheckedCategoryDTO
    {

        public int ID { get; set; } 

        public string Name { get; set; } 


        public bool IsSelect { get; set; }    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class GetCategoryDTO
    {
        // her bir kategori için o kategoriye ait yalnızca id ve isim bilgiisnin taşınması için bu dto yu oluşturmayı tercih ettik.

        public int ID { get; set; }  // categoryID

        public string Name { get; set; } // categoryName

       
        public bool IsSelect { get; set; }    // 
    }
}

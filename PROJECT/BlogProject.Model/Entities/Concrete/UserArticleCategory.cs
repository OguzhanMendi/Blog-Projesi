using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.Entities.Concrete
{
  public  class UserArticleCategory
    {
        public int CategoryId { get; set; }

        public  Category Category { get; set; }




        public int ArticleId { get; set; }
        public  Article Article { get; set; }
    }
}

using BlogProject.Dal.Repositories.Interfaces.Abstract;
using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
  public  interface IArticleRepository: IBaseRepository<Article>
    {
    }
}

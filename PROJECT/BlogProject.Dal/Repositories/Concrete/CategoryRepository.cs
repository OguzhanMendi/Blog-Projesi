using BlogProject.Dal.Context;
using BlogProject.Dal.Repositories.Abstract;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Dal.Repositories.Concrete
{
 public   class CategoryRepository :BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ProjectContext context):base(context)
        {

        }
    }
}

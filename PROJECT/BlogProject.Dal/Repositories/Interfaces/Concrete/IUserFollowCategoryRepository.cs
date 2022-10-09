using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
   public  interface IUserFollowCategoryRepository
    {

        void Create(UserFollowCategory entity);

        void Delete(UserFollowCategory entity);



        TResult GetByDefault<TResult>
          (
              Expression<Func<UserFollowCategory, TResult>> selector,        // seçim
              Expression<Func<UserFollowCategory, bool>> expression,         // sorgu /filtreleme
              Func<IQueryable<UserFollowCategory>, IIncludableQueryable<UserFollowCategory, object>> include = null  //içermesini istediğimiz tablolar/ include ettiğimiz,edeceğimiz tabloları burada söylüyoruz ki eğer böyle tablolar yoksa bu parametre null bırakılabilir bir parametre aynı zamanda.
          );



        List<TResult> GetByDefaults<TResult>
           (
           Expression<Func<UserFollowCategory, TResult>> selector,    // seçim
           Expression<Func<UserFollowCategory, bool>> expression,     // sorgu
           Func<IQueryable<UserFollowCategory>, IIncludableQueryable<UserFollowCategory, object>> include = null,   // include etme - nullable
           Func<IQueryable<UserFollowCategory>, IOrderedQueryable<UserFollowCategory>> orderBy = null          //  sıralama - order- nullable

           );



        UserFollowCategory GetDefault(Expression<Func<UserFollowCategory, bool>> expression);

        // Aynı sorgudan dönen T tipli nesneleri barındıran liste yapısını döner.
        List<UserFollowCategory> GetDefaults(Expression<Func<UserFollowCategory, bool>> expression);  // expression=sorgu cümlesi
    }
}

using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
   public interface IUserArticleCategoryRepository 
    {
        void Create(UserArticleCategory entity);

        void Delete(UserArticleCategory entity);



        TResult GetByDefault<TResult>
          (
              Expression<Func<UserArticleCategory, TResult>> selector,        // seçim
              Expression<Func<UserArticleCategory, bool>> expression,         // sorgu /filtreleme
              Func<IQueryable<UserArticleCategory>, IIncludableQueryable<UserArticleCategory, object>> include = null  //içermesini istediğimiz tablolar/ include ettiğimiz,edeceğimiz tabloları burada söylüyoruz ki eğer böyle tablolar yoksa bu parametre null bırakılabilir bir parametre aynı zamanda.
          );



        List<TResult> GetByDefaults<TResult>
           (
           Expression<Func<UserArticleCategory, TResult>> selector,    // seçim
           Expression<Func<UserArticleCategory, bool>> expression,     // sorgu
           Func<IQueryable<UserArticleCategory>, IIncludableQueryable<UserArticleCategory, object>> include = null,   // include etme - nullable
           Func<IQueryable<UserArticleCategory>, IOrderedQueryable<UserArticleCategory>> orderBy = null          //  sıralama - order- nullable

           );



        UserArticleCategory GetDefault(Expression<Func<UserArticleCategory, bool>> expression);

        // Aynı sorgudan dönen T tipli nesneleri barındıran liste yapısını döner.
        List<UserArticleCategory> GetDefaults(Expression<Func<UserArticleCategory, bool>> expression);  // expression=sorgu cümlesi


    }





}

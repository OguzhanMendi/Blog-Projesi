using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
   public interface IUserPasswordRepository
    {
        void Create(UserPassword entity);

       
        void Delete(UserPassword entity);



        TResult GetByDefault<TResult>
          (
              Expression<Func<UserPassword, TResult>> selector,        // seçim
              Expression<Func<UserPassword, bool>> expression,         // sorgu /filtreleme
              Func<IQueryable<UserPassword>, IIncludableQueryable<UserPassword, object>> include = null  //içermesini istediğimiz tablolar/ include ettiğimiz,edeceğimiz tabloları burada söylüyoruz ki eğer böyle tablolar yoksa bu parametre null bırakılabilir bir parametre aynı zamanda.
          );



        List<TResult> GetByDefaults<TResult>
           (
           Expression<Func<UserPassword, TResult>> selector,    // seçim
           Expression<Func<UserPassword, bool>> expression,     // sorgu
           Func<IQueryable<UserPassword>, IIncludableQueryable<UserPassword, object>> include = null,   // include etme - nullable
           Func<IQueryable<UserPassword>, IOrderedQueryable<UserPassword>> orderBy = null          //  sıralama - order- nullable

           );



        UserPassword GetDefault(Expression<Func<UserPassword, bool>> expression);

        // Aynı sorgudan dönen T tipli nesneleri barındıran liste yapısını döner.
        List<UserPassword> GetDefaults(Expression<Func<UserPassword, bool>> expression);  // expression=sorgu cümlesi


    }
}

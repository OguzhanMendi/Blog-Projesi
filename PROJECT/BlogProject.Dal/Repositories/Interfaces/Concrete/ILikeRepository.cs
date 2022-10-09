using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
  public  interface ILikeRepository
    {
        // DİKKAT => like sınıfı baseden kalıtım almıyor bu yüzden baseRepodan kalıtım alamayacak ama zaten like için tüm CRUDLAR söz konusu değil.  

        // like nesnesini oluşturabilirsiniz/ silebilirsiniz yani bir makaleyi beğenebilirsiniz yada beğeninizi geri alabilirsiniz hepsi bu.
        void Create(Like entity);

        void Delete(Like entity);


        TResult GetByDefault<TResult>
       (
           Expression<Func<Like, TResult>> selector,        // seçim
           Expression<Func<Like, bool>> expression,         // sorgu /filtreleme
           Func<IQueryable<Like>, IIncludableQueryable<Like, object>> include = null  //içermesini istediğimiz tablolar/ include ettiğimiz,edeceğimiz tabloları burada söylüyoruz ki eğer böyle tablolar yoksa bu parametre null bırakılabilir bir parametre aynı zamanda.
       );



        List<TResult> GetByDefaults<TResult>
           (
           Expression<Func<Like, TResult>> selector,    // seçim
           Expression<Func<Like, bool>> expression,     // sorgu
           Func<IQueryable<Like>, IIncludableQueryable<Like, object>> include = null,   // include etme - nullable
           Func<IQueryable<Like>, IOrderedQueryable<Like>> orderBy = null          //  sıralama - order- nullable

           );



        Like GetDefault(Expression<Func<Like, bool>> expression);

        // Aynı sorgudan dönen T tipli nesneleri barındıran liste yapısını döner.
        List<Like> GetDefaults(Expression<Func<Like, bool>> expression);  // expression=sorgu cümlesi


    }
}

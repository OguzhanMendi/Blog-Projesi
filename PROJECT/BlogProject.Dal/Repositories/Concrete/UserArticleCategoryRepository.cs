using BlogProject.Dal.Context;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Concrete
{
    public class UserArticleCategoryRepository : IUserArticleCategoryRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<UserArticleCategory> _table;

        public UserArticleCategoryRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<UserArticleCategory>();

        }
        public void Create(UserArticleCategory entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserArticleCategory entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public TResult GetByDefault<TResult>(Expression<Func<UserArticleCategory, TResult>> selector, Expression<Func<UserArticleCategory, bool>> expression, Func<IQueryable<UserArticleCategory>, IIncludableQueryable<UserArticleCategory, object>> include = null)
        {
            IQueryable<UserArticleCategory> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
            if (include != null)    // include parametresi varsa
            {
                query = include(query);
            }
            if (expression != null)  // expression parametresi varsa
            {
                query = query.Where(expression);
            }
            return query.Select(selector).First();  // en son dönen tablo/tablolardan seçim işlemi de yapıp TEK bir TResult nesnesi döndürür.

            // önce dahil etme işlemi varsa yapar sonra filtreler sonra seçer ve sonucu döndürür.
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<UserArticleCategory, TResult>> selector, Expression<Func<UserArticleCategory, bool>> expression, Func<IQueryable<UserArticleCategory>, IIncludableQueryable<UserArticleCategory, object>> include = null, Func<IQueryable<UserArticleCategory>, IOrderedQueryable<UserArticleCategory>> orderBy = null)
        {

            IQueryable<UserArticleCategory> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
            if (include != null)    // include parametresi varsa
            {
                query = include(query);
            }
            if (expression != null)  // expression parametresi varsa
            {
                query = query.Where(expression);
            }
            if (orderBy != null)  // orderBy parametrsi varsa
            {
                return orderBy(query).Select(selector).ToList();
            }
            return query.Select(selector).ToList();

        }

        public UserArticleCategory GetDefault(Expression<Func<UserArticleCategory, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<UserArticleCategory> GetDefaults(Expression<Func<UserArticleCategory, bool>> expression)
        {
            return _table.Where(expression).ToList();

        }
    }
}


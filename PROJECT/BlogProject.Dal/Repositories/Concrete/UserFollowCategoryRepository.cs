using BlogProject.Dal.Context;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Dal.Repositories.Concrete
{
    public class UserFollowCategoryRepository : IUserFollowCategoryRepository
    {

        private readonly ProjectContext _context;
        private readonly DbSet<UserFollowCategory> _table;

        public UserFollowCategoryRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<UserFollowCategory>();

        }

        public void Create(UserFollowCategory entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserFollowCategory entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();

        }



        public TResult GetByDefault<TResult>(Expression<Func<UserFollowCategory, TResult>> selector, Expression<Func<UserFollowCategory, bool>> expression, Func<IQueryable<UserFollowCategory>, IIncludableQueryable<UserFollowCategory, object>> include = null)
        {
            IQueryable<UserFollowCategory> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
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

        public List<TResult> GetByDefaults<TResult>(Expression<Func<UserFollowCategory, TResult>> selector, Expression<Func<UserFollowCategory, bool>> expression, Func<IQueryable<UserFollowCategory>, IIncludableQueryable<UserFollowCategory, object>> include = null, Func<IQueryable<UserFollowCategory>, IOrderedQueryable<UserFollowCategory>> orderBy = null)
        {

            IQueryable<UserFollowCategory> query = _table;   // tablomuuzu sorgulanabilir T tipini barındıran bir tablo olarak atadık.
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

        public UserFollowCategory GetDefault(Expression<Func<UserFollowCategory, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<UserFollowCategory> GetDefaults(Expression<Func<UserFollowCategory, bool>> expression)
        {
            return _table.Where(expression).ToList();

        }
    }
}

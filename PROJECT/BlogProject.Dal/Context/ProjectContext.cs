using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfigurations.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Dal.Context
{
    // DbContextten değil IdentityDbContextten kalıtım aldık çünkü projede idetity kütüphanesini kullanacağız.
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions options):base(options) 
        {

        }


        public DbSet<Article>  Articles { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Comment>  Comments { get; set; }
        public DbSet<Like>  Likes { get; set; }
        public DbSet<UserFollowCategory>  FollowCategories { get; set; }
        
        public DbSet<AppUser>  AppUsers { get; set; }
        public DbSet<UserArticleCategory> UserArticleCategories { get; set; }
        public DbSet<UserPassword>  UserPasswords { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new IdentityRoleMap());
            builder.ApplyConfiguration(new UserFollowedCategoryMap());
            builder.ApplyConfiguration(new UserArticleCategoryMap());
            builder.ApplyConfiguration(new UserPasswordMap());

            base.OnModelCreating(builder);
        }



    }
}

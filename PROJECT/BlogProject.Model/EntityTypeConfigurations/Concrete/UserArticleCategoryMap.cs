using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class UserArticleCategoryMap : IEntityTypeConfiguration<UserArticleCategory>
    {
        public  void Configure(EntityTypeBuilder<UserArticleCategory> builder)
        {


            builder.HasKey(a => new { a.ArticleId, a.CategoryId });

        }  
    }
}

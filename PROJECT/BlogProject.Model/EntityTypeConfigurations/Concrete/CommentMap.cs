using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.Text).IsRequired(true);

            // Comment entitysinde baseden geleln ıd yi ezip biz içinde bulunan appUserId ve articleId nin de anahtar olduğunu söyledik.
           // builder.HasKey(a => new { a.AppUserId, a.ArticleId });

            base.Configure(builder);
        }
    }
}

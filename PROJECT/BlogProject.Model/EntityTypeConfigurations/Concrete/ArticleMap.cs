using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class ArticleMap :BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired(true);
            builder.Property(a => a.ImagePath).IsRequired(true);

            // bir makalenin bir kullanıcııs vardır ve bunlar appUserId ile bağlıdır.

            builder.HasOne(a => a.AppUser).WithMany(a => a.Articles).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);
            // deleteBehavior.Restrict  => ebeveyn - çocuk ilişkisi. yani makaleyi silebilriz ama makalenin oluşturucusunu sildiğimizde makalenin kime ait olacağı bilinemeyeceği için buna izin vermez.

            //bir makalenin bir kategorisi vardır ve bunlar kategoriId üzerinden birbirine bağlıdır.
            // builder.HasOne(a => a.Category).WithMany(a => a.Articles).HasForeignKey(a => a.CategoryId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }


    }
}

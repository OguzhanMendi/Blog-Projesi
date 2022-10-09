using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public  override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.FirstName).IsRequired(true);
            builder.Property(a => a.LastName).HasMaxLength(45).IsRequired(true);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.ImagePath).IsRequired(true); // fotoğrafsız kullanıcı olamaz

            base.Configure(builder);
        }
    }
}

using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class UserPasswordMap : IEntityTypeConfiguration<UserPassword>
    {
        public void Configure(EntityTypeBuilder<UserPassword> builder)
        {
            //builder.HasKey(a => new { a.AppUserId, a.Password });   // UniQ

            builder.HasKey(a=> new { a.UserPwdId});
            builder.Property(a => a.AppUserId).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);

        }
    }
}

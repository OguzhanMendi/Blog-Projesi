using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class UserFollowedCategoryMap : IEntityTypeConfiguration<UserFollowCategory>
    {
        public void Configure(EntityTypeBuilder<UserFollowCategory> builder)
        {
            builder.HasKey(a => new { a.AppUserId, a.CategoryId });
            // likeMapte olduğu gibi birliktelikleri eşsiz olmuş olacak.
        }
    }
}

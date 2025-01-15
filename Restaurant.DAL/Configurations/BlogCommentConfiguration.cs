using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Configurations
{
    public class BlogCommentConfiguration : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Rating).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Comment_Rating_Range", "[Rating] >= 0 AND [Rating] <= 5"));
        }
    }
}

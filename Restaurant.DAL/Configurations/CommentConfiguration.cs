using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class CommentConfiguration:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder) 
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Rating).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Comment_Rating_Range", "[Rating] >= 0 AND [Rating] <= 5"));
        }
    }
}

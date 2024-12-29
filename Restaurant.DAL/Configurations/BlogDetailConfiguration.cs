using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class BlogDetailConfiguration : IEntityTypeConfiguration<BlogDetail>
    {
        public void Configure(EntityTypeBuilder<BlogDetail> builder) 
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

            builder.HasIndex(x => new { x.LanguageId, x.BlogId }).IsUnique();

        }
    }
}

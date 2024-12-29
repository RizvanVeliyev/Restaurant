using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class BlogCategoryDetailConfiguration : IEntityTypeConfiguration<BlogCategoryDetail>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryDetail> builder) 
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

            builder.HasIndex(x => new { x.LanguageId, x.BlogCategoryId }).IsUnique();

        }
    }
}

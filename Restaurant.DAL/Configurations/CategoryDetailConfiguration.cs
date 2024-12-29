using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class CategoryDetailConfiguration:IEntityTypeConfiguration<CategoryDetail>
    {
        public void Configure(EntityTypeBuilder<CategoryDetail> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);

            builder.HasIndex(x => new { x.LanguageId, x.CategoryId }).IsUnique(); 

        }

    }
}

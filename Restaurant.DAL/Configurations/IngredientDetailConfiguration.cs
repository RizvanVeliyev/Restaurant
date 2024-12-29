using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class IngredientDetailConfiguration:IEntityTypeConfiguration<IngredientDetail>
    {
        public void Configure(EntityTypeBuilder<IngredientDetail> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);

            //builder.HasIndex(x => new { x.LanguageId}).IsUnique();

        }
    }

}

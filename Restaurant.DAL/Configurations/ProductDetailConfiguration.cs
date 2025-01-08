using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class ProductDetailConfiguration:IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder) 
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

            builder.ToTable(t => t.HasCheckConstraint("CK_Product_Price", "[Price] >= 0"));

            builder.HasIndex(x => new { x.LanguageId, x.ProductId }).IsUnique();

        }
    }
}

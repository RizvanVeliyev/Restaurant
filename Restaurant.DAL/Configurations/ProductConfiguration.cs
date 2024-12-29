using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(256);

            builder.Property(p => p.Price).IsRequired().HasPrecision(5, 2);
            builder.ToTable(t => t.HasCheckConstraint("CK_Product_Price", "[Price] >= 0"));
        }
    }
}

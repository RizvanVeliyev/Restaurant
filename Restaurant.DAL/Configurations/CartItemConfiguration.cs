using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class CartItemConfiguration:IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder) 
        {
            builder.Property(x => x.Count).IsRequired();

            builder.HasIndex(x => new {  x.ProductId }).IsUnique();

        }
    }
}

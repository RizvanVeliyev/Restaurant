using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder) 
        {
            builder.Property(x => x.Count).IsRequired();

            builder.HasIndex(x => new { x.ProductId, x.OrderId }).IsUnique();
        }
    }
}

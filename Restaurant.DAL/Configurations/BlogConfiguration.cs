using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder) 
        {
            builder.Property(x => x.Author).IsRequired().HasMaxLength(128);
            builder.Property(x=>x.ImageUrl).IsRequired().HasMaxLength(256);
            
        }
    }
}

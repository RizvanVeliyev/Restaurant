using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class AboutConfiguration:IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder) 
        { 
            builder.Property(x=>x.ImagePath).IsRequired().HasMaxLength(256);
        }
    }
}

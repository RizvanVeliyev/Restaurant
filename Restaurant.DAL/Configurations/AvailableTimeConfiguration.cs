using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class AvailableTimeConfiguration:IEntityTypeConfiguration<AvailableTime>
    {
        public void Configure(EntityTypeBuilder<AvailableTime> builder)
        {
            builder.Property(x=>x.Time).IsRequired();
        }
    }

}

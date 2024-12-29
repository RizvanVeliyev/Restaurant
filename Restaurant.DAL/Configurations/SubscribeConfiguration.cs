using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class SubscribeConfiguration:IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder) 
        {
            builder.Property(x => x.IsSubscribed).HasDefaultValue(false);

            builder.Property(c => c.Email)
                  .IsRequired()
                  .HasMaxLength(255);

            builder.ToTable(t => t.HasCheckConstraint("CK_Contact_Email", "Email LIKE '%@%' AND Email LIKE '%.%'"));

        }
    }
}

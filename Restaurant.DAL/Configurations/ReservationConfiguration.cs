using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.Configurations
{
    public class ReservationConfiguration:IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder) 
        { 
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.Time).IsRequired();
            builder.ToTable(t => t.HasCheckConstraint("CK_Reservation_People_Range", "[NumberOfPeople] >= 1 AND [NumberOfPeople] <= 10"));


            builder.Property(c => c.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(15);

            //builder.ToTable(t => t.HasCheckConstraint("CK_Contact_PhoneNumber", "PhoneNumber LIKE '+%' AND LEN(PhoneNumber) >= 10 AND LEN(PhoneNumber) <= 15"));
            //contact yox reservation olmalidi sehv gedib
        }
    }
}

using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Reservation:BaseEntity
    {

        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Time { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = [];
        public int NumberOfPeople { get; set; }
        public string ReservationNumber { get; set; } = null!;


    }
}

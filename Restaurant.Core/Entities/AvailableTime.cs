using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{

    public class AvailableTime:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Time { get; set; } = null!;
    }

}

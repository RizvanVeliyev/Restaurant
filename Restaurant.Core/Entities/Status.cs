using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Status : BaseEntity
    {
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<StatusDetail> StatusDetails { get; set; } = [];
    }
}

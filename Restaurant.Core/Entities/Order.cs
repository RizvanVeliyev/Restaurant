using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; } = null!; 
        public DateTime OrderedTime { get; set; }   
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

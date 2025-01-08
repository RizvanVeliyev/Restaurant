using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Order : BaseAuditableEntity
    {
        public AppUser? AppUser { get; set; } = null!;
        public string? AppUserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int OrderNo { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;





    }
}

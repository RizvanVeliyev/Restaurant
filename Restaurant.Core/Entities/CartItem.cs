using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
     
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public AppUser AppUser { get; set; } = null!;
        public string AppUserId { get; set; } = null!;

        public int Count { get; set; } 
        public decimal TotalPrice => Product.Price * Count;

    }
}

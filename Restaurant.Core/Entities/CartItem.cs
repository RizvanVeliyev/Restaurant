using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
     
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public int Quantity { get; set; } 
        public decimal TotalPrice => Product.Price * Quantity;

    }
}

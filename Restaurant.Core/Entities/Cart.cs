using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Cart : BaseEntity
    {
        public AppUser AppUser { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}

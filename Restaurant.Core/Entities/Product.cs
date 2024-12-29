using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Product:BaseAuditableEntity
    {
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Ingredient>? Ingredients { get; set; } = [];
        public ICollection<ProductImage> ProductImages { get; set; } = [];
        public ICollection<ProductDetail> ProductDetails { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
    }
}

using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class ProductIngredient:BaseEntity
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public int IngredientId { get; set; }
    }
}

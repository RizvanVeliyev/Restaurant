using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public ICollection<IngredientDetail> IngredientDetails { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
    }
}

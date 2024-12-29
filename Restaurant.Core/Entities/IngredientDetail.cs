using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class IngredientDetail : BaseEntity
    {
        public string Name { get; set; } = null!; 
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public int LanguageId { get; set; }
        public Language Language { get; set; } = null!;
    }
}

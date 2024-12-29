using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class CategoryDetail:BaseEntity
    {
        public string Name { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public Language Language { get; set; } = null!;
        public int LanguageId { get; set; }

    }
}

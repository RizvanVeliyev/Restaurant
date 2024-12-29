using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogCategoryDetail:BaseEntity
    {
        public string Name { get; set; } = null!;
        public BlogCategory BlogCategory { get; set; } = null!;
        public int BlogCategoryId { get; set; }
        public Language Language { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}

using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogDetail:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Blog Blog { get; set; } = null!;
        public int BlogId { get; set; }

        //public Language Language { get; set; } = null!;
        //public int LanguageId { get; set; }

    }
}

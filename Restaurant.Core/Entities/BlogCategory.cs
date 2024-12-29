using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogCategory:BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Blog> Blogs = [];
    }
}

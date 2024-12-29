using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogCategory:BaseEntity
    {
        public ICollection<Blog> Blogs = [];
    }
}

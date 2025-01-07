using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogCategory:BaseEntity
    {
        public ICollection<BlogCategoryDetail> BlogCategoryDetails { get; set; } = [];

        public ICollection<Blog> Blogs = [];
    }
}

using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Category:BaseAuditableEntity
    {
        public ICollection<CategoryDetail> CategoryDetails { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
    }
}

using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Category:BaseEntity
    {
        public ICollection<CategoryDetail> CategoryDetails { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
        public bool IsDeleted { get; set; } = false;//helelik bele yazdimnormalda baseauditableentityden miras almalidi!

    }
}

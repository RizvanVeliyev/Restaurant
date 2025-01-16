using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Language:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public ICollection<CategoryDetail> CategoryDetails { get; set; } = [];
        public ICollection<BlogCategoryDetail> BlogCategoryDetails { get; set; } = [];
        public ICollection<BlogDetail> BlogDetails { get; set; } = [];
        public ICollection<ProductDetail> ProductDetails { get; set; } = [];


    }


}

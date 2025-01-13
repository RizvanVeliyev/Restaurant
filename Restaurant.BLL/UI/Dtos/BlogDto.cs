using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Dtos.BlogDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class BlogDto
    {
        public List<BlogGetDto> Blogs { get; set; } = new();
        public List<BlogCategoryGetDto> BlogCategories { get; set; } = new();
    }
}

using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCategoryDetailDtos;
using Restaurant.BLL.Dtos.CategoryDtos;

namespace Restaurant.BLL.Dtos.BlogCategoryDtos
{
    public class BlogCategoryCreateDto:IDto
    {
        public List<BlogCategoryGetDto> BlogCategories { get; set; } = [];

        public List<BlogCategoryDetailCreateDto> BlogCategoryDetails { get; set; } = [];
    }
}

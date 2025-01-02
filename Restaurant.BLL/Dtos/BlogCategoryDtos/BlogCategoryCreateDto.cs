using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCategoryDetailDtos;

namespace Restaurant.BLL.Dtos.BlogCategoryDtos
{
    public class BlogCategoryCreateDto:IDto
    {
        public List<BlogCategoryDetailCreateDto> BlogCategoryDetails { get; set; } = [];
    }
}

using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCategoryDetailDtos;
using Restaurant.BLL.Dtos.CategoryDtos;

namespace Restaurant.BLL.Dtos.BlogCategoryDtos
{
    public class BlogCategoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public List<BlogCategoryGetDto> BlogCategories { get; set; } = [];

        public List<BlogCategoryDetailUpdateDto> BlogCategoryDetails { get; set; } = [];


    }
}

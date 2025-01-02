using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CategoryDetailDtos;

namespace Restaurant.BLL.Dtos.CategoryDtos
{
    public class CategoryCreateDto:IDto
    {
        public List<CategoryGetDto> Categories { get; set; } = [];
        public List<CategoryDetailCreateDto> CategoryDetails { get; set; } = [];
    }
}

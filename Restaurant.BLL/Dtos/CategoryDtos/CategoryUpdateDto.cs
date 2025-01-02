using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CategoryDetailDtos;

namespace Restaurant.BLL.Dtos.CategoryDtos
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; }
       
        public List<CategoryGetDto> Categories { get; set; } = [];
        public List<CategoryDetailUpdateDto> CategoryDetails { get; set; } = [];
    }
}

using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class MenuDto
    {
        public List<ProductGetDto> Products { get; set; } = new();
        public List<CategoryGetDto> Categories { get; set; } = new();

    }
}

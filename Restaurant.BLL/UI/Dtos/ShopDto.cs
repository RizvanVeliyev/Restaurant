using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.CommonDtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class ShopDto
    {
        public PaginateDto<ProductGetDto> Products { get; set; } = new();
        public List<CategoryGetDto> Categories { get; set; } = new();
    }
}

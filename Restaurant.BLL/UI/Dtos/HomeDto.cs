using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AboutDtos;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class HomeDto : IDto
    {
        public List<CategoryGetDto> Categories { get; set; } = [];
        public List<ProductGetDto> Products { get; set; } = [];
        public AboutGetDto? About { get; set; }
    }
}

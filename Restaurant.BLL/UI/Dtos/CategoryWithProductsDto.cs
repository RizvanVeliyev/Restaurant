using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class CategoryWithProductsDto
    {
        public string CategoryName { get; set; } = null!;
        public List<ProductGetDto> Products { get; set; } = new();
    }
}

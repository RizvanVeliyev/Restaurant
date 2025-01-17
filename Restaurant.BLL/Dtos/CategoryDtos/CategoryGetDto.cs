using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.Dtos.CategoryDtos
{
    public class CategoryGetDto:IDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; } = null!;
        
        public List<ProductGetDto> Products { get; set; } = [];
    }
}

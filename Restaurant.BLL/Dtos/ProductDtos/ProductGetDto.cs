using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.ProductDtos
{
    public class ProductGetDto:IDto
    {
        public decimal Price { get; set; }

    }
}

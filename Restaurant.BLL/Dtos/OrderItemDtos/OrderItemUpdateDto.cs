using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.Dtos.OrderItemDtos
{
    public class OrderItemUpdateDto : IDto
    {
        public int Id { get; set; }
        public ProductGetDto Product { get; set; } = null!;
        public int Count { get; set; }
    }
}

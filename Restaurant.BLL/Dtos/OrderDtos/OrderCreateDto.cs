using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.OrderItemDtos;

namespace Restaurant.BLL.Dtos.OrderDtos
{
    public class OrderCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public List<OrderItemCreateDto>? OrderItems { get; set; } = [];
    }
}

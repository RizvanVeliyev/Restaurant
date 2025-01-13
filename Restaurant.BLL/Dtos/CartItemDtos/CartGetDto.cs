using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CartItemDtos
{
    public class CartGetDto : IDto
    {
        public int Count { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public List<CartItemGetDto> Items { get; set; } = [];
    }
}

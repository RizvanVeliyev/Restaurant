using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CartItemDtos
{
    public class CartItemCreateDto:IDto
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; } // Məhsulun miqdarı
    }
}

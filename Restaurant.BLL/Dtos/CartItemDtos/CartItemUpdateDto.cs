using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CartItemDtos
{
    public class CartItemUpdateDto:IDto
    {
        public int Id { get; set; } // Səbət məhsulunun ID-si

        public int Quantity { get; set; }
    }
}

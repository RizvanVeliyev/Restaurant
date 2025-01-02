using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CartItemDtos
{
    public class CartItemGetDto:IDto
    {
        public int Id { get; set; } // Səbət məhsulunun ID-si
        //public ProductGetDto Product { get; set; } = null!; // Məhsulun DTO-su
        public int Quantity { get; set; } // Məhsulun miqdarı
        //public decimal TotalPrice => Product.Price * Quantity;
    }
}

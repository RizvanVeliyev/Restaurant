using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.Dtos.CartItemDtos
{
    public class CartItemGetDto:IDto
    {
        public int Id { get; set; } // Səbət məhsulunun ID-si
        //public ProductGetDto Product { get; set; } = null!; // Məhsulun DTO-su
        public int Count { get; set; } // Məhsulun miqdarı
        //public decimal TotalPrice => Product.Price * Quantity;

        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; } = null!;
    }
}

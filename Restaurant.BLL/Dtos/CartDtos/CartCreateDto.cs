using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CartItemDtos;

namespace Restaurant.BLL.Dtos.CartDtos
{
    public class CartCreateDto:IDto
    {
        public string AppUserId { get; set; } = null!; // İstifadəçinin ID-si
        public List<CartItemCreateDto> CartItems { get; set; } = []; // Səbət məhsulları
    }
}


using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CartItemDtos;

namespace Restaurant.BLL.Dtos.CartDtos
{
    public class CartGetDto:IDto
    {
        public int Id { get; set; } // Səbətin ID-si
        public string AppUserId { get; set; } = null!; // İstifadəçinin ID-si
        public List<CartItemGetDto> CartItems { get; set; } = []; // Səbətdəki məhsullar
        //public decimal TotalPrice => CartItems.Sum(item => item.TotalPrice); // Ümumi səbət qiyməti

    }
}

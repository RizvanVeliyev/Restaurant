using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.CartItemDtos;

namespace Restaurant.BLL.Dtos.CartDtos
{
    public class CartUpdateDto:IDto
    {
        public int Id { get; set; } // Yenilənəcək səbətin ID-si

        public List<CartItemUpdateDto> CartItems { get; set; } = [];
    }
}

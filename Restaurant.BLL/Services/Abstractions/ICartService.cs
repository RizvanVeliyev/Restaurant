using Restaurant.BLL.Dtos.CartItemDtos;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(int id, int count = 1);
        Task<bool> DecreaseToCartAsync(int id);
        Task RemoveToCartAsync(int id);
        Task<CartGetDto> GetCartAsync(Languages language = Languages.Azerbaijan);
        Task ClearCartAsync();
    }
}

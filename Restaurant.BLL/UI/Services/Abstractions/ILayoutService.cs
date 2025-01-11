using Restaurant.BLL.Dtos.CartItemDtos;

namespace Restaurant.BLL.UI.Services.Abstractions
{
    public interface ILayoutService
    {
        Task<CartGetDto> GetCartAsync();
        string GetSelectedLanguage();
    }
}

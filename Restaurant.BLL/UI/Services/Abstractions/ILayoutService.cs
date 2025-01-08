using Restaurant.BLL.Dtos.CartDtos;

namespace Restaurant.BLL.UI.Services.Abstractions
{
    public interface ILayoutService
    {
        Task<CartGetDto> GetCartAsync();
        string GetSelectedLanguage();
    }
}

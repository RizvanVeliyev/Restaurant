using Restaurant.BLL.Dtos.CartDtos;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.UI.Services.Implementations
{
    internal class LayoutService : ILayoutService
    {
        
        private readonly ICartService _basketService;

        public LayoutService(ICartService basketService)
        {
            
            _basketService = basketService;
        }

       

        public async Task<CartGetDto> GetCartAsync()
        {
            return await _basketService.GetCartAsync(Constants.SelectedLanguage);
        }

        public string GetSelectedLanguage()
        {
            if (Constants.SelectedLanguage == Languages.English)
                return "en";
            else if (Constants.SelectedLanguage == Languages.Russian)
                return "ru";

            return "az";

        }

        
    }
}

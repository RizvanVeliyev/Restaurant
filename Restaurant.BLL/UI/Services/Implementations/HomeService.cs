using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.UI.Services.Implementations
{
    public class HomeService : IHomeService
    {
        
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        public HomeService( ICategoryService categoryService, IProductService productService, IAboutService aboutService)
        {
          
            _categoryService = categoryService;
            _productService = productService;
            _aboutService = aboutService;
        }

        public async Task<HomeDto> GetHomeDtoAsync(Languages language = Languages.Azerbaijan)
        {
            var categories = await _categoryService.GetAllAsync(language);
            var products = await _productService.GetAllAsync(language);
            var about = (await _aboutService.GetAllAsync(language)).FirstOrDefault();

            HomeDto dto = new HomeDto()
            {
                Products = products,
                Categories=categories,
                About = about
            };

            return dto;
        }
    }
}

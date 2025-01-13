using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.Services.Implementations;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public ShopController(IProductService productService, ICategoryService categoryService, ICommentService commentService, ILanguageService languageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _commentService = commentService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync(_language);
            var categories=await _categoryService.GetAllAsync(_language);
            var shopDto = new ShopDto
            {
                Products = products,
                Categories = categories
            };

            return View(shopDto);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}

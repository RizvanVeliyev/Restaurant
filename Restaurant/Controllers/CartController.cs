using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Enums;
using Restaurant.Extensions;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _service;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public CartController(ICartService service, ILanguageService languageService)
        {
            _service = service;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetCartAsync(_language);
            return View(result);
        }
        public async Task<IActionResult> GetCartSection()
        {
            var cart = await _service.GetCartAsync(_language);
            return PartialView("_cartSectionPartial", cart);
        }
        public async Task<IActionResult> RemoveToCart(int id)
        {
            await _service.RemoveToCartAsync(id);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }

        
        public IActionResult RedirectForCart()
        {
            _languageService.RenderSelectedLanguage();
            return PartialView("_cartModalPartial");
        }


        public async Task<IActionResult> AddToCart(int id, int count = 1)
        {
            await _service.AddToCartAsync(id, count);

            return RedirectToAction(nameof(RedirectForCart));
        }
        public async Task<IActionResult> DecreaseToCart(int id)
        {
            await _service.DecreaseToCartAsync(id);

            return RedirectToAction(nameof(RedirectForCart));
        }



        

    }
}

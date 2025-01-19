using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.Core.Enums;
using Restaurant.Extensions;
using Restaurant.Models;
using System.Diagnostics;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILanguageService _languageService;
        private readonly ISubscribeService _subscribeService;
        private readonly Languages _language;
        public HomeController(IHomeService homeService, ILanguageService languageService, ISubscribeService subscribeService)
        {
            _homeService = homeService;
            _languageService = languageService;
            _subscribeService = subscribeService;
            _language = _languageService.RenderSelectedLanguage();
        }

        public async Task<IActionResult> Index(int? categoryId)
        {

            var dto = await _homeService.GetHomeDtoAsync(_language,categoryId);

            return View(dto);
        }




        public IActionResult SelectCulture(string culture)
        {
            _languageService.SelectCulture(culture);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> AddSubscriber(SubscribeCreateDto dto)
        {
            var result = await _subscribeService.CreateAsync(dto, ModelState);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }
    }
}

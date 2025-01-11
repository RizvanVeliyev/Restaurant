using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public ContactController(IContactService contactService, ILanguageService languageService)
        {
            _contactService = contactService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }

        public async Task<IActionResult> Index()
        {

            var result = await _contactService.GetContactDtoAsync(_language);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactDto dto)
        {
            var result = await _contactService.SendEmailAsync(dto, ModelState);

            if (!result)
            {
                return View(dto); 
            }

            return RedirectToAction(nameof(ThankYou));

        }


        public IActionResult ThankYou()
        {
            return View();
        }


    }
}

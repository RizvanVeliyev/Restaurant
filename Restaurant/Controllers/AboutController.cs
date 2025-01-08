﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public AboutController(IAboutService aboutService, ILanguageService languageService)
        {
            _aboutService = aboutService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }

        public async Task<IActionResult> Index()
        {
            var result = await _aboutService.GetAllAsync(_language);

            return View(result);
        }
    }
}

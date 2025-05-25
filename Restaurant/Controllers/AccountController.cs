using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.AppUserDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Extensions;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public AccountController(IAuthService authService, ILanguageService languageService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _authService = authService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto, ModelState);

            if (result is false)
                return View(dto);

            if (!string.IsNullOrWhiteSpace(dto.ReturnUrl))
                return Redirect(dto.ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto, ModelState);

            if (result is false)
                return View(dto);

           

            return RedirectToAction("Index", "Home");
        }



     

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId is null || token is null)
                return RedirectToAction("Index", "Error"); ;

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null) 
                return RedirectToAction("Index", "Error"); ;

            await _userManager.ConfirmEmailAsync(user, token);

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            var returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }


        public async Task<IActionResult> VerifyEmail(VerifyEmailDto dto)
        {
            var result = await _authService.VerifyEmailAsync(dto, ModelState);

            return RedirectToAction("Index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class EmailController : Controller
    {
        private readonly ISubscribeService _service;

        public EmailController(ISubscribeService service)
        {
            _service = service;
        }

        public IActionResult Index(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SubscribeEmailDto dto)
        {
            var result = await _service.SendEmailToSubscribres(dto, ModelState);

            if (result is false)
                return View(dto);


            return RedirectToAction(nameof(Index), routeValues: new { isSuccess = true });
        }
    }
}

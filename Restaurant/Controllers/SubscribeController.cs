using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _service;

        public SubscribeController(ISubscribeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (result is false)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}

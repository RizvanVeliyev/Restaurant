using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.SubscribeDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _service;

        public SubscribeController(ISubscribeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscribeCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (result is false)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetUpdatedDtoAsync(id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubscribeUpdateDto dto)
        {
            var result = await _service.UpdateAsync(dto, ModelState);

            if (result is false)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

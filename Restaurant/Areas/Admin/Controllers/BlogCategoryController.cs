using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryService _service;

        public BlogCategoryController(IBlogCategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var result = await _service.GetCreateDtoAsync();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCategoryCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (result is false)
            {
                dto = await _service.GetCreateDtoAsync(dto);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetUpdatedDtoAsync(id);

            if (result is null)
                return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogCategoryUpdateDto dto)
        {
            var result = await _service.UpdateAsync(dto, ModelState);


            if (result is false)
            {
                dto = await _service.GetUpdatedDtoAsync(dto);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

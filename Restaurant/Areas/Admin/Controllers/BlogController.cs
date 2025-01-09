using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService blogService)
        {
            _service = blogService;
        }



        public async Task<IActionResult> Index()
        {
            var blogs = await _service.GetAllAsync();//Page-le getirmekde olar baxarsan!

            return View(blogs);
        }

        public async Task<IActionResult> Create()
        {
            var dto = await _service.GetCreatedDtoAsync();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (result is false)
            {
                dto = await _service.GetCreatedDtoAsync(dto);
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

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateDto dto)
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

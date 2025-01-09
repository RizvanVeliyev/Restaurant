using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }



        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();//Page-le getirmekde olar baxarsan!

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var dto = await _service.GetCreatedDtoAsync();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
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
        public async Task<IActionResult> Update(ProductUpdateDto dto)
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

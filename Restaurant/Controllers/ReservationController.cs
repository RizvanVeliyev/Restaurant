using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.BLL.Services.Abstractions;

namespace Restaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        public IActionResult ReserveTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveTable(ReservationCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (result is false)
                return View(dto);

            return RedirectToAction(nameof(ConfirmReservation));
        }

        public IActionResult ConfirmReservation()
        {
            return View();
        }
    }
}

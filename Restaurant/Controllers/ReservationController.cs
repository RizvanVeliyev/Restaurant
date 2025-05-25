using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.ReservationDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Services.Abstractions;

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
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.CreateAsync(dto, ModelState);

            if (!result)
                return View(dto);

            // Ən son rezervasiyanı əldə et
            var latestReservation = await _service.GetLatestReservationAsync(dto.Name, dto.PhoneNumber);

            if (latestReservation == null)
                return RedirectToAction(nameof(ReserveTable)); // Əgər tapılmadısa, rezervasiya səhifəsinə geri qayıt

            var result2 = await _service.SendEmailAsync(dto, ModelState);


            return RedirectToAction(nameof(ConfirmReservation), new { id = latestReservation.ReservationNumber });
        }


        public async Task<IActionResult> ConfirmReservation(int id)
        {
            var reservation = await _service.GetReservationAsync(id);

            // Təsdiq səhifəsinə göndərilir
            return View(reservation);
        }
    }
}

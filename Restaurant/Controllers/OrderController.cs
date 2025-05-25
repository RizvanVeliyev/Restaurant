using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos;
using Restaurant.BLL.Dtos.OrderDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;
        private readonly IPaymentService _paymentService;


        public OrderController(IOrderService orderService, ILanguageService languageService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetUserUnSubmitOrderAsync(_language);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderCreateDto dto)
        {
            var result = await _orderService.CreateAsync(dto, ModelState);

            if (result is false)
            {
                var order = await _orderService.GetUserUnSubmitOrderAsync(_language);
                dto.OrderItems = order.OrderItems;
                return View(dto);
            }

            return RedirectToAction("Redirect");
        }


        public IActionResult Redirect()
        {
            string? url = Request.Cookies["paymentUrl"];
            if (!string.IsNullOrWhiteSpace(url))
            {
                Response.Cookies.Delete("paymentUrl");

                return Redirect(url);
            }

            return RedirectToAction("List", "Order");
        }

        public async Task<IActionResult> CheckPayment(PaymentCheckDto dto)
        {
            var result = await _paymentService.CheckPaymentAsync(dto);

            if (result is true)
                return RedirectToAction("List", "Order");

            return RedirectToAction("Shop", "Index");
        }
        //[Authorize]
        public async Task<IActionResult> List()
        {
            var result = await _orderService.GetUserOrdersAsync(_language);

            return View(result);
        }

        public async Task<IActionResult> CancelOrder(int id)
        {
            await _orderService.CancelOrderAsync(id);

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> RepairOrder(int id)
        {
            await _orderService.RepairOrderAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}

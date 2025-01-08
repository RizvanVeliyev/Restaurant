using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

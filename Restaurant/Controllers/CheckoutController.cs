﻿using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

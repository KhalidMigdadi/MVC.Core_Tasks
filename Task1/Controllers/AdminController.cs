﻿using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}

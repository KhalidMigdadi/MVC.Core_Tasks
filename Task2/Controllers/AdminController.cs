using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}

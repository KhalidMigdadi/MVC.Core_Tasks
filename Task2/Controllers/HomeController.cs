using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Retrieve the user's name from session
            string userName = HttpContext.Session.GetString("Name");

            if (userName != null)
            {
                ViewBag.WelcomeMessage = "Welcome, " + userName;
            }
            else
            {
                ViewBag.WelcomeMessage = "Welcome, Guest";
            }

            return View();
        }

        //[HttpPost]
        //public IActionResult GetName(string Name)
        //{
        //    string name = HttpContext.Session.GetString(Name);
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

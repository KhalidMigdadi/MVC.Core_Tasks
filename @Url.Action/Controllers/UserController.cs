using Microsoft.AspNetCore.Mvc;

namespace _Url.Action.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

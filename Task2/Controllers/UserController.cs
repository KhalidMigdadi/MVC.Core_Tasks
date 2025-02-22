
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Task2.Controllers
{
    public class UserController : Controller
    {


        const string SessionUserName = "_UserName";
        const string SessionEmail = "_Email";
        const string SessionPassword = "_Password";


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandelRegister(string email, string pass, string Name)
        {
            if (email != null && pass != null)
            {

                TempData["email"] = email;
                TempData["password"] = pass;
                TempData["username"] = Name;

                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }


        }
        public IActionResult Login()
        {





            string data = Request.Cookies["userInfo"];
            string data_2 = Request.Cookies["username"];
            string data_3 = Request.Cookies["password"];

            if (data != null)
                return RedirectToAction("Index", "Home");
            else
                return View();

        }

        [HttpPost]
        public IActionResult HandelLogin(string Email, string Password, string rememberMe)
        {

            if (TempData["username"] == null)
            {
                return RedirectToAction("Login");
            }

            HttpContext.Session.SetString(SessionUserName, TempData["username"].ToString());
            HttpContext.Session.SetString(SessionEmail, TempData["email"].ToString());
            HttpContext.Session.SetString(SessionPassword, TempData["password"].ToString());


            string? email = HttpContext.Session.GetString(SessionEmail);
            string? password = HttpContext.Session.GetString(SessionPassword);


            if (email != null && password != null)
            {


                if (Email == email && Password == password)
                {
                    if (rememberMe != null)
                    {
                        CookieOptions obj = new CookieOptions();
                        obj.Expires = DateTime.Now.AddDays(2);

                        Response.Cookies.Append("userInfo", TempData["email"].ToString(), obj);
                        Response.Cookies.Append("username", TempData["username"].ToString(), obj);

                    }


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Profile()
        {
            string PrintedName = HttpContext.Session.GetString("_UserName");
            string PrintedEmail = HttpContext.Session.GetString("_Email");
            string PrintedPhone = HttpContext.Session.GetString("_Phone");
            string PrintedAddress = HttpContext.Session.GetString("_Address");

            if (string.IsNullOrEmpty(PrintedName) || string.IsNullOrEmpty(PrintedEmail))
            {
                TempData["ErrorMSG"] = "Please log in to view your profile.";
                return RedirectToAction("Login", "User");
            }

            ViewBag.Name = PrintedName;
            ViewBag.Email = PrintedEmail;
            ViewBag.Phone = PrintedPhone ?? "N/A";
            ViewBag.Address = PrintedAddress ?? "N/A";

            return View();
        }



        [HttpPost]
        public IActionResult UpdateProfile(string Name, string Email, string Phone, string Address)
        {
            // Update session values
            HttpContext.Session.SetString("_UserName", Name);
            HttpContext.Session.SetString("_Email", Email);
            HttpContext.Session.SetString("_Phone", Phone ?? "");
            HttpContext.Session.SetString("_Address", Address ?? "");

            // Update cookies (if needed)
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append("username", Name, options);
            Response.Cookies.Append("userInfo", Email, options);
            Response.Cookies.Append("phone", Phone ?? "", options);
            Response.Cookies.Append("address", Address ?? "", options);

            // Redirect back to profile page with updated data
            return RedirectToAction("Profile");
        }

        public IActionResult EditProfile()
        {
            ViewBag.Name = HttpContext.Session.GetString("_UserName");
            ViewBag.Email = HttpContext.Session.GetString("_Email");
            ViewBag.Phone = HttpContext.Session.GetString("_Phone") ?? "";
            ViewBag.Address = HttpContext.Session.GetString("_Address") ?? "";

            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }


            //Response.Cookies.Delete("userInfo");

            return RedirectToAction("Login");
        }



       


        public IActionResult Admin()
        {
            return View();
        }
    }
}






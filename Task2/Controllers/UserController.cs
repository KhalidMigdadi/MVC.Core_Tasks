using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for Session


namespace Task2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleLogin(string email, string pass)
        {
            // Check if user exists in session
            string storedEmail = HttpContext.Session.GetString("Email");
            string storedPassword = HttpContext.Session.GetString("Password");

            if (email == storedEmail && pass == storedPassword)
            {
                // Successfully logged in
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMSG"] = "Invalid Email or Password";
                return RedirectToAction("Login");  
            }
        



            //if (email == "khalid@gmail.com" && pass == "1234")
            //{
            //    // Store user data in session
            //    HttpContext.Session.SetString("Email", email);

            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    TempData["ErrorMSG"] = "Invalid UserName or password";
            //    return RedirectToAction("Login");
            //}
            
        }

        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public IActionResult HandleRegister(string Name, string email, string pass, string RPass)
        {
            // Check if password and repeated password match
            if (pass != RPass)
            {
                TempData["ErrorMSG"] = "Passwords do not match!";
                return RedirectToAction("Register");
            }

            // Store user data in Session
            HttpContext.Session.SetString("Name", Name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", pass);


            TempData["MSG"] = "Registered Successfully";
            return RedirectToAction("Login");
        }

        public IActionResult Profile()
        {

            string PrintedName = HttpContext.Session.GetString("Name");
            string PrintedEmail = HttpContext.Session.GetString("Email"); // becuase its storted in register as 'Email'

            if (string.IsNullOrEmpty(PrintedName) || string.IsNullOrEmpty(PrintedEmail))
            {
                TempData["ErrorMSG"] = "Please log in to view your profile.";
                return RedirectToAction("Login", "User");
            }

            ViewBag.Name = PrintedName;
            ViewBag.Email = PrintedEmail;

            return View();
        }

        
    }
}

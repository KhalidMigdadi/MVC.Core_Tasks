using System.Runtime.Intrinsics.X86;
using CardTasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardTasks.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.CurrentUsers.ToList(); 
            return View(users);
        }



        public IActionResult Register()
        {
            
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Register(CurrentUser user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(user);
        //    }

        //    // Check if the email already exists
        //    var existingUser = _context.CurrentUsers.FirstOrDefault(x => x.Email == user.Email); // X is row and user in input
        //    if (existingUser != null)
        //    {
        //        ModelState.AddModelError("Email", "This email is already registered.");
        //        return View(user);
        //    }

        //    _context.Add(user);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}



        [HttpPost]
        public async Task<IActionResult> Register(CurrentUser user)
        {
            // Check if the email already exists in the database asynchronously
            var existingUser = await _context.CurrentUsers
                                              .FirstOrDefaultAsync(x => x.Email == user.Email);

            //  Check if the model state is valid (data validation using annotations).
            if (!ModelState.IsValid)
            {
                return View(user);  // Return the user object with validation errors if invalid.
            }

            if (existingUser != null)
            {
                // Add a custom error if the email is already registered
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(user); // Return the view with the model (user) and the error message
            }

            // If no user exists with that email, add the new user asynchronously
            _context.Add(user);
            await _context.SaveChangesAsync();  // Save changes asynchronously

            return RedirectToAction("Index");  // Redirect to the Index action
        }








        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }






        // POST: UserController/Edit/5
        [HttpPost]
        public ActionResult Login(CurrentUser user)
        {
            try
            {
                var user1 = _context.CurrentUsers.FirstOrDefault(x => x.Email == user.Email && x.Name == user.Name);
                if (user1 != null)
                {
                    TempData["UserName"] = user.Name;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

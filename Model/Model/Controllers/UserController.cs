using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.Controllers
{
    public class UserController : Controller
    {
        // MyDbContext=> link between DB and Models
        // _context => obj from MyDbContext class
        // how can i insert data to obj ? from costructor 


        // i will use it in all contraller to access all tables in DB
        // from controller to Model => i use _context (bridge)
        private readonly MyDbContext _context; // _context access DB but here is empty

        public UserController(MyDbContext context) // constr. so i can access to all tables inside the DB
        {
            _context = context; //  allows the controller to access the database.

        }

        // Action to display all users (GET)
        public IActionResult Index()
        {
            // when i want to send data to table i will remeber the _context as list
             //                   data  shape
            var users = _context.Users.ToList();  // Fetch all users from the database
            return View(users);  // Pass users to the view
        }





        // Action to show the form to add a new user (GET)
        public IActionResult Create()
        {
            return View();  // Show the Create view with a form to add user
        }





        // Action to handle form submission and save the new user (POST)
        [HttpPost]
        public IActionResult Create(User user) // we sent the data from form and they will be inside container (class User) and user is obj and inside them the data and i will pass the data as user word
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);  // Add new user(that you enter them in form) to the database (MyDbContext) like git Add .
                _context.SaveChanges();    // Save changes to the database => means added it sucessfully to the DB like git push
                return RedirectToAction("Index");  // Redirect to the Index page to see all users
            }

            

            // If the model is invalid, return to the Create page with the entered data
            return View(user);
        }





        // Edit

        public IActionResult Edit(int id) // int id ? => becuase i want to edit one recored only  and its arrive from link
        {
          
            var user = _context.Users.Find(id); // what is hte data type here and find is search on the primary key columns
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }



    }
}

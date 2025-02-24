using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Model.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList(); // Get the list of departments from the database

            return View(departments);  // Pass it to the view
        }


        public IActionResult Create()
        {


            return View();
        }


        [HttpPost]
        public IActionResult Create(Department dep)
        {
            if(ModelState.IsValid)
            {
                _context.Departments.Add(dep);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is invalid, return to the Create page with the entered data
            return View(dep);
        }









        


    }
}

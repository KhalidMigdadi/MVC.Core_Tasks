using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CardTasks.Models;

namespace CardTasks.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Details(int Id)
        {

            var student = _context.Products.Find(Id);

            return View(student);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

      

        public IActionResult Edit(int Id)
        {

            var student = _context.Products.Find(Id);

            return View(student);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        public IActionResult Delete(int Id)
        {
            var product = _context.Products.Find(Id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        
    }
}

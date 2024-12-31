using Microsoft.AspNetCore.Mvc;
using NimapCrud.Models;
using System.Linq;

namespace NimapCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject ApplicationDbContext
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category/Index
        public IActionResult Index()
        {
            // Retrieve categories from the database and pass them to the view
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent Cross-Site Request Forgery (CSRF) attacks
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // Add the new category to the database
                _context.Categories.Add(category);
                _context.SaveChanges();
                // Redirect to the Index action to view the list of categories
                return RedirectToAction(nameof(Index));
            }
            // If the model state is not valid, return the Create view with the current category data
            return View(category);
        }
    }
}

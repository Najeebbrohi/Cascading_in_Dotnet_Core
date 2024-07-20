using CascadingDropdownCore.Areas.Identity.Data;
using CascadingDropdownCore.Models;
using CascadingDropdownCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CascadingDropdownCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            //var products = new List<Product>();

            var countries = _context.Countries.ToList();
            var states = _context.States.ToList();

            var data = new HomeViewModel();
            //data.Categories = new SelectList(categories, "Id", "CategoryName");
            //data.Countries = countries;

            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            //ViewBag.Products = new SelectList(products, "Id", "Name");

            ViewBag.Countries = new SelectList(countries, "Id","CountryName");
            ViewBag.States = new SelectList(states, "Id", "StateName");

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetProductsByCategory(int id)
        {
            return Json(_context.Products.Where(x=>x.CategoryId == id).ToList());
        }
        public JsonResult GetStateByCountry(int id)
        {
            return Json(_context.States.Where(x=>x.CountryId == id).ToList());
        }
        public JsonResult GetCityByState(int id)
        {
            return Json(_context.Cities.Where(x=>x.StateId == id).ToList());
        }
    }
}

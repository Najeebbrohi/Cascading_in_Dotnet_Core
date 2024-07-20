using CascadingDropdownCore.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CascadingDropdownCore.Controllers
{
    public class CascadingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CascadingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult Country()
        {
            var countries = _context.Countries.ToList();
            return Json(countries);
        }
        public JsonResult State(int id) {
            var states = _context.States.Where(x=>x.CountryId == id).ToList();
            return Json(states);
        }
        public JsonResult City(int id) {
            var cities = _context.Cities.Where(x=>x.StateId == id).ToList();
            return Json(cities);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

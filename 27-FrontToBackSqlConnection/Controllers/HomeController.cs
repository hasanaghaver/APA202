using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Slider> sliders = _context.Sliders
                .Where(s => s.IsDeleted == false)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToList();

            HomeVM homeVM = new()
            {
                Sliders = sliders
            };

            return View(homeVM);
        }

    }
}

using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products
                .Where(p=>!p.IsDeleted)
                .Take(4)
                .Include(p=>p.ProductImages.Where(pi=> pi.IsPrimary != null && !pi.IsDeleted))
                .ToListAsync();


            List<Slider> sliders = await _context.Sliders
                .Where(s => s.IsDeleted == false)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToListAsync();

            HomeVM homeVM = new()
            {
                Sliders = sliders,
                Products = products
            };

            return View(homeVM);
        }

    }
}

using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products
                .Where(p=>!p.IsDeleted)
                .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary != null && !pi.IsDeleted))
                .ToListAsync();

            ShopVm shopVM = new() { Products = products };

            return View(shopVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id<1) return BadRequest();
            
            Product? product = await _context.Products
                .Where(p=>!p.IsDeleted)
                .Include(p=>p.Catagory)
                .Include(p=>p.ProductImages)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if(product == null) return NotFound();

            List<Product> releatedProducts = await _context.Products
                .Where(p=>!p.IsDeleted)
                .Where(p=>p.Catagory == product.Catagory && p.Id != product.Id)
                .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary != null && !pi.IsDeleted))
                .ToListAsync();

            DetailVm detailVm = new() { Product = product, ReleatedProducts = releatedProducts };

            return View(detailVm);
        }
    }
}

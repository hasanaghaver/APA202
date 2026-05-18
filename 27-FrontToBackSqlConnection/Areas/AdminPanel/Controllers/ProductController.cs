using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVMs = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Catagory)
                .Include(p => p.ProductImages)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    CatagoryName = p.Catagory.Name,
                    Image = p.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();

            return View(productGetVMs);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM
            {
                Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync()
            };
            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync();
            
            if (!ModelState.IsValid)
            {
                return View(productCreateVM);
            }

            bool exsistCatagory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CatagoryId);

            if (!exsistCatagory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CatagoryId), "Catagory does not exsist!");
                return View(productCreateVM);
            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description,
                CatagoryId = productCreateVM.CatagoryId.Value
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
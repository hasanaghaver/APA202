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
                Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };
            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

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

            if (productCreateVM.TagIds is not null)
            {
                bool exsistTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
                if (exsistTag)
                {
                    ModelState.AddModelError(nameof(productCreateVM.TagIds), "Tag does not exsist!");
                    return View(productCreateVM);
                }

            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description,
                CatagoryId = productCreateVM.CatagoryId.Value,
            };

            if(productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tId=> new ProductTag { TagId = tId}).ToList();
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if(id is null || id <1) return BadRequest();

            Product? product = await _context.Products.Include(p=>p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CatagoryId = product.CatagoryId,
                TagIds = product.ProductTags.Select(pt=>pt.TagId).ToList(),
                Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t=>!t.IsDeleted).ToListAsync()
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

            productUpdateVM.Categories = await _context.Catagories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productUpdateVM);

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            bool exsistCatagory = productUpdateVM.Categories.Any(c=> c.Id == productUpdateVM.CatagoryId);
            if (!exsistCatagory)
            {
                ModelState.AddModelError(nameof(productUpdateVM.CatagoryId), "Catagory does not exsist");
                return View(productUpdateVM);
            }

            product.Name = productUpdateVM.Name;
            product.Price = productUpdateVM.Price;
            product.SKU = productUpdateVM.SKU;
            product.CatagoryId = productUpdateVM.CatagoryId.Value;
            product.Description = productUpdateVM.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
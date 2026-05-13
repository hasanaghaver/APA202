using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CatagoryController : Controller
    {
        private readonly AppDbContext _context;

        public CatagoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Catagory> catagories = await _context.Catagories
                .Where(c=>!c.IsDeleted)
                .Include(p=>p.Products.Where(pr=>!pr.IsDeleted))
                .ToListAsync();
            return View(catagories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Catagory catagory)
        {
            if(!ModelState.IsValid) return View();

            bool exsistCatagory = await _context.Catagories.AnyAsync(c=>c.Name.Trim() == catagory.Name.Trim());

            if (exsistCatagory)
            {
                ModelState.AddModelError("Name", "Catagory alredy exist!");
                return View();
            }

            await _context.AddAsync(catagory);
            await _context.SaveChangesAsync();


            //return View("Index");

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Catagory? catagory = await _context.Catagories
                .Include(p=>p.Products.Where(pi=>!pi.IsDeleted))
                .FirstOrDefaultAsync(c=>c.Id == id);

            if (catagory == null) return NotFound();
            return View(catagory);
        }

      
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Catagory? exsistCatagory = await _context.Catagories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (exsistCatagory is null) return NotFound();


            return View(exsistCatagory);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Catagory catagory)
        {
            if (id is null || id < 1) return BadRequest();

            Catagory? exsistCatagory = await _context.Catagories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (exsistCatagory is null) return NotFound();

            if (!ModelState.IsValid) return View();

            bool result = await _context.Catagories.AnyAsync(c => c.Name == catagory.Name && c.Id != catagory.Id);

            if (result)
            {
                ModelState.AddModelError(nameof(Catagory.Name), "Catagory alredy exsist!");
                return View();
            }
            exsistCatagory.Name = catagory.Name;

             await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Catagory? exsistCatagory = await _context.Catagories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (exsistCatagory is null) return NotFound();

            _context.Catagories.Remove(exsistCatagory);

            //exsistCatagory.IsDeleted = true;

            await _context.SaveChangesAsync(true);

            return RedirectToAction(nameof(Index));
        }
    }
}

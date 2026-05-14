using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();
            return View(sliders);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!sliderCreateVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "File type is incorret");
                return View();
            }
            if (!sliderCreateVM.Photo.CheckFileSize(FileSize.Mb, 2))
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "File size must be less 2Mb");
                return View();
            }

            Slider slider = new()
            {
                Title = sliderCreateVM.Title,
                Description = sliderCreateVM.Description,
                Subtitle = sliderCreateVM.Subtitle,
                Order = sliderCreateVM.Order,
                Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images")
            };


            await _context.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders.Where(s => !s.IsDeleted).FirstOrDefaultAsync(s => s.Id == id);

            if (slider is null) return NotFound();

            SliderDetailVM sliderDetailVM = new() 
            { 
                Title = slider.Title,
                Description = slider.Description,
                Subtitle = slider.Subtitle,
                Order = slider.Order,
                Image = slider.Image
            };


            return View(sliderDetailVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders.Where(s => !s.IsDeleted).FirstOrDefaultAsync(s => s.Id == id);

            if (slider is null) return NotFound();

            slider.Image.DeleteFile(_env.WebRootPath,"assets","images","website-images");

            _context.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders.Where(s => !s.IsDeleted).FirstOrDefaultAsync(s => s.Id == id);

            if (slider is null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new()
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Order = slider.Order,
                Description = slider.Description,
                Image = slider.Image
            };
            return View(sliderUpdateVM);
        }
    }
}

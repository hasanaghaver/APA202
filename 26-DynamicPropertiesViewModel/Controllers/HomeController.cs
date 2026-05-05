using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        List<Student> _students = new List<Student>
        {
            new Student { Id = 1,Name = "Nihad", Surname ="Aslanov"},
            new Student { Id = 2,Name = "Fuad", Surname ="Movsumov"},
            new Student { Id = 5,Name = "Revan", Surname ="Qaragoz"}
        };

        List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher { Id = 1,Name = "Ali", Salary = 2400 },
            new Teacher { Id = 2,Name = "Ehmed", Salary = 300 }
        };



        public IActionResult Index()
        {
            //ViewBag.Students = _students;
            //ViewData["Students"] = _students;
            //TempData["Name"] = "Elmir";

            HomeVM homeVM = new()
            {
                Teachers = _teachers,
                Students = _students
            };


            return View(homeVM);
        }

        public IActionResult Details()
        {
            return View();
        }

        [Route("korporative-satislar")]
        public IActionResult CorporativeSales()
        {
            return View();
        }
    }
}

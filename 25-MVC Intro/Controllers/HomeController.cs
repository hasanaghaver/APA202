using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var student = new JsonResult(new { id = 1, name = "Ali", surname = "Quliyev" });

            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }
            return RedirectToAction(nameof(Index), "Product");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

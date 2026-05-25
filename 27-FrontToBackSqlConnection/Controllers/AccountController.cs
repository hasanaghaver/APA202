using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController( UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) return View(registerVM);

            AppUser user = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };
            IdentityResult result = await userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {

                    if (error.Description.Contains("Email"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Email), "Email alredy exsist");
                    }
                    if (error.Description.Contains("Password"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Password), "Password must be min 8 symbols and must be min 1 capital letter, min 1 symbol");
                    }
                    if (error.Description.Contains("UserName"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Username), "Username must be min 3 symbol");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View(registerVM);
            }


            return Json(registerVM);
        }

    }
}

using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

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
                foreach (IdentityError error in result.Errors)
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

            await userManager.AddToRoleAsync(user, UserRole.Member.ToString());

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            AppUser? user = await userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == loginVM.UsernameOrEmail || u.Email == loginVM.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Username,Email or password is incorrect");
                return View(loginVM);
            }

            var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPresitent, true);


            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is blocked! please try letter!");
                return View(loginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username,Email or password is incorrect");
                return View(loginVM);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> CreateRoles()
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

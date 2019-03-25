using System.Threading.Tasks;
using BG_DAL.Entityes;
using BrowserGame.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUserData> _userManager;
        private readonly SignInManager<ApplicationUserData> _signInManager;

        public AccountController(UserManager<ApplicationUserData> userManager, SignInManager<ApplicationUserData> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Страница Регистрации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Регистрирует
        /// </summary>
        /// <param name="model">переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserData user = new ApplicationUserData { Email = model.Email, UserName = model.Email, Year = model.Year};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
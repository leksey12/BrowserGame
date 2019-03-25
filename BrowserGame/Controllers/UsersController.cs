
using System.Linq;
using System.Threading.Tasks;
using BG_DAL.Entityes;
using BrowserGame.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class UsersController : Controller
    {
        UserManager<ApplicationUserData> _userManager;

        public UsersController(UserManager<ApplicationUserData> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        /// <summary>
        /// Страница добавления пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// добавляет
        /// </summary>
        /// <param name="model"> переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserData user = new ApplicationUserData { Email = model.Email, UserName = model.Email, Year = model.Year, Name = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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

        /// <summary>
        /// страница изменения пользователя
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUserData user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Year = user.Year, Name = user.Name };
            return View(model);
        }

        /// <summary>
        /// изменяет 
        /// </summary>
        /// <param name="model">переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserData user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Year = model.Year;
                    user.Name = model.Name;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            ApplicationUserData user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Страница смены пароля
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            ApplicationUserData user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        /// <summary>
        /// изменяет пароль
        /// </summary>
        /// <param name="model">переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserData user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}
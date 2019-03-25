using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BG_DAL.Entityes;
using BrowserGame.Models;
using BrowserGame.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame.Controllers
{
   [Authorize(Roles = "Администратор")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUserData> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUserData> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        /// <summary>
        /// Страница добавления роли
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Добавляет роль
        /// </summary>
        /// <param name="name">переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }

        /// <summary>
        /// Удаляет роль
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Страница всех пользователей
        /// </summary>
        /// <returns></returns>
        public IActionResult UserList() => View(_userManager.Users.ToList());

        /// <summary>
        /// Страница смены роли для пользователя
        /// </summary>
        /// <param name="userId">переменная</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            ApplicationUserData user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        
        /// <summary>
        /// Изменяет роль для пользователя
        /// </summary>
        /// <param name="userId">переменная</param>
        /// <param name="roles">переменная</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            ApplicationUserData user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
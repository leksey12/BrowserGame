using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrowserGame.Models;
using Microsoft.Extensions.Logging;
using BrowserGame.Services;

namespace BrowserGame.Controllers
{
    public class PersonagesController : Controller
    {
        private readonly IPersonageServices _personage;
        private readonly ILogger<PersonagesController> logger;
        public PersonagesController(IPersonageServices personage, ILogger<PersonagesController> logger)
        {
            _personage = personage;
            this.logger = logger;
        }

        // GET: Personages
        /// <summary>
        /// Метод представления списка персонажей
        /// </summary>
        /// <param name="sortOrder"> сортировка</param>
        /// <param name="searchString">поиск</param>
        /// <returns></returns>
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["CapitalSortParm"] = sortOrder == "Capital" ? "date_desc" : "Capital";
            ViewData["CurrentFilter"] = searchString;
            var personages = from s in _personage.GetAllPersonages()
                             select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                personages = personages.Where(s => s.Name.Contains(searchString)
                                       || s.Category.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    personages = personages.OrderByDescending(s => s.Name);
                    break;
                case "Capital":
                    personages = personages.OrderBy(s => s.Capital);
                    break;
                case "date_desc":
                    personages = personages.OrderByDescending(s => s.Capital);
                    break;
                default:
                    personages = personages.OrderBy(s => s.Name);
                    break;

            }
            return View(personages);
        }

        /// <summary>
        /// Информация о персонаже выбранный по id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        // GET: Personages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                logger.LogCritical("Error NotFound");
                return NotFound();
            }

            var personage = await _personage.GetPersonageByIdAsync(id);
            if (personage == null)
            {
                return NotFound();
            }
            logger.LogInformation("Действие информация о персонаже");
            return View(personage);
        }

        /// <summary>
        /// Страница добавления
        /// </summary>
        /// <returns></returns>
        // GET: Personages/Create
       // [Authorize(Roles = "Администратор")]
        public IActionResult Create()
        {
            logger.LogInformation("Действие создания персонажа");
            return View();
        }

        /// <summary>
        /// Добавляет в таблицу нового персонажа
        /// </summary>
        /// <param name="personage">переменная</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personage personage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personage.SavePersonage(personage);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                                   "Повторите попытку, и если проблема не устранена, " + "обратитесь к системному администратору.");
            }
            return View(personage);
        }

        /// <summary>
        /// Изменяет персонажа по id
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="personage">переменная</param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(int? id, Personage personage)
        {
            if (id == null)
            {
                logger.LogCritical("Error NotFound");
                return NotFound();
            }
            {
                try
                {
                    _personage.SavePersonage(personage);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                        "Повторите попытку, и если проблема не устранена, " + "обратитесь к системному администратору.");
                }
            }
            return View(personage);

        }

        /// <summary>
        /// Страница изменения персонажа по id
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        //[Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Edit(int? id)
        {
            var personage = await _personage.GetPersonageByIdAsync(id);
            if (personage == null)
            {
                return NotFound();
            }
            logger.LogInformation("Действие информация о персонаже");
            return View(personage);
        }

       /// <summary>
       /// Страница удаления персонажа по id
       /// </summary>
       /// <param name="id">идентификатор</param>
       /// <param name="saveChangesError">ошибка сохранения</param>
       /// <returns></returns>
        // GET: Personages/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personage = await _personage.GetPersonageByIdAsync(id);
            if (personage == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Ошибка удаления. Попробуйте еще раз, и если проблема не устранена " + "обратитесь к системному администратору.";
            }

            return View(personage);
        }

        /// <summary>
        /// Удаляет Персонажа по id
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="personage">переменная</param>
        /// <returns></returns>
        // POST: Personages/Delete/5
        //[Authorize(Roles = "Администратор")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personage.DeletePersonageAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
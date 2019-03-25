
using BrowserGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserGame.Services
{
    /// <summary>
    /// Интерфейс работы с персонажем
    /// </summary>
    public interface IPersonageServices
    {
        /// <summary>
        /// Список всех персонажей
        /// </summary>
        /// <returns></returns>
        IEnumerable<Personage> GetAllPersonages();

        /// <summary>
        /// Информация о персонаже по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Personage> GetPersonageByIdAsync(int? id);

        /// <summary>
        /// Добавление нового/изменение персонажа и сохранение
        /// </summary>
        /// <param name="personage"></param>
        int SavePersonage(Personage personage, string operation);

        /// <summary>
        /// Удаление Персонажа
        /// </summary>
        /// <param name="personage"></param>
        Task DeletePersonageAsync(int id);


    }
}

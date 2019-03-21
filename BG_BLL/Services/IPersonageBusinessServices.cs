using BrowserGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BG_BLL.Services
{
   public interface IPersonageBusinessServices
    {
        /// <summary>
        /// Список всех персонажей
        /// </summary>
        /// <returns></returns>
        IEnumerable<PersonageBusiness> GetAllPersonages();

        /// <summary>
        /// Информация о персонаже по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PersonageBusiness> GetPersonageByIdAsync(int? id);

        /// <summary>
        /// Добавление нового/изменение персонажа и сохранение
        /// </summary>
        /// <param name="personage"></param>
        void SavePersonage(PersonageBusiness personage);

        /// <summary>
        /// Удаление Персонажа
        /// </summary>
        /// <param name="personage"></param>
        Task DeletePersonageAsync(int id);


    }
}

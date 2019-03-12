using BrowserGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BG_BLL.Interfaces
{
   public interface IPersonage
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
        void SavePersonage(Personage personage);

        /// <summary>
        /// Удаление Персонажа
        /// </summary>
        /// <param name="personage"></param>
        void DeletePersonage(Personage personage);
        
    }
}

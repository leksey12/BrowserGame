using BG_DAL.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.Models
{
    /// <summary>
    /// Класс пользователь
    /// </summary>
    public class ApplicationUser: ApplicationUserData
    {
        /// <summary>
        /// Имя Пользователя
        /// </summary>
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
         [DisplayName("Год")]
        public int Year { get; set; }
    }
}

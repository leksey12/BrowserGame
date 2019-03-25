using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BG_DAL.Entityes
{
    /// <summary>
    /// Класс пользователь
    /// </summary>
    public class ApplicationUserData : IdentityUser
    {
        /// <summary>
        /// Имя Пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int Year { get; set; }
    }
}

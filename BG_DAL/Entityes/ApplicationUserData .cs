using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BG_DAL.Entityes
{
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

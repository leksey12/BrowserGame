using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BG_DAL.Entityes
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Имя Пользователя
        /// </summary>
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int Year { get; set; }
    }
}

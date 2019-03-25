using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    /// <summary>
    /// Класс добавления пользователя
    /// </summary>
    public class CreateUserViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [Range(1960, 2020, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    /// <summary>
    /// Класс изменения пользователя
    /// </summary>
    public class EditUserViewModel
    {
        public string Id { get; set; }

        /// <summary>
        /// Email 
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Email { get; set; }

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

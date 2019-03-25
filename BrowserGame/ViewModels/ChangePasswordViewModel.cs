using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    /// <summary>
    /// Класс изменения пароля
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        /// <summary>
        /// Старый пароль
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}

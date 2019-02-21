using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Вы не ввели старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}

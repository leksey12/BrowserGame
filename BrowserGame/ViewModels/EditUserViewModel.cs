using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Введите только 4 не меньше не больше.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Name { get; set; }
    }
}

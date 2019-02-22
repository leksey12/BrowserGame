using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.ViewModels
{
    public class CreateUserViewModel
    {
        
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [Range(1960, 2020, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        public string Name { get; set; }
    }
}

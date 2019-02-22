using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.Models
{
    public class Personage
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Данное поле должно быть заполнено")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("История Футболиста")]
        public string History { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("Владения Игрока")]
        public string Possession { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Группа Категории должна состоять от 5-20 символов.")]
        [DisplayName("Категория")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("Капитал")]
        [DataType(dataType: DataType.Currency)]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Капитал должен состоять от 6-25 символов.")]
        public string Capital { get; set; }


    }

}

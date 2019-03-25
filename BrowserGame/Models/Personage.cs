using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.Models
{
    /// <summary>
    /// Класс персонаж
    /// </summary>
    public class Personage
    {
        /// <summary>
        /// Идентификатор персонажа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// О футболисте
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("История Футболиста")]
        public string History { get; set; }

        /// <summary>
        /// Достоинтсва 
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("Владения Игрока")]
        public string Possession { get; set; }

        /// <summary>
        /// К какой категории относится 
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Группа Категории должна состоять от 5-20 символов.")]
        [DisplayName("Категория")]
        public string Category { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [DisplayName("Капитал")]
        [DataType(dataType: DataType.Currency)]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Капитал должен состоять от 6-25 символов.")]
        public string Capital { get; set; }


    }

}

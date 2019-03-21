using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BG_DAL.Entityes
{
    public class PersonageData
    {
        /// <summary>
        /// Идентификатор персонажа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// О футболисте
        /// </summary>
        public string History { get; set; }

        /// <summary>
        /// Достоинтсва 
        /// </summary>
        public string Possession { get; set; }

        /// <summary>
        /// К какой категории относится 
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public string Capital { get; set; }


    }

}

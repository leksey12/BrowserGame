using BrowserGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG_BLL.Interfaces
{
   public interface IPersonage
    {
        IEnumerable<Personage> GetAllPersonages();
        Personage GetPersonageById(int Id);
        void SavePersonage(Personage achieve);
        void DeletePersonage(Personage achieve);
    }
}

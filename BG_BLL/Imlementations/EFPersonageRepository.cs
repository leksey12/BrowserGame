using BG_BLL.Interfaces;
using BrowserGame.Data;
using BrowserGame.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BG_BLL.Imlementations
{
    public class EFPersonageRepository : IPersonage
    {
        private ApplicationDbContext context;
        public EFPersonageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Personage> GetAllPersonages()
        {
            return context.Personages.ToList();
        }

        //получаем по id
        public async Task<Personage> GetPersonageByIdAsync(int? id)
        {
            var personage = await context.Personages
                .FirstOrDefaultAsync(m => m.Id == id);
            return personage.Adapt<Personage>();

        }

        public void SavePersonage(Personage personage)
        {
            if (personage.Id == 0)
                context.Personages.Add(personage);
            else
                context.Entry(personage).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePersonage(Personage personage)
        {
            context.Personages.Remove(personage);
            context.SaveChanges();
        }
       
    }
}
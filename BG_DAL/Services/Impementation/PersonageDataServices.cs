using BG_DAL.EFContext;
using BG_DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_DAL.Services.Impementation
{
   public class PersonageDataServices : IPersonageDataServices
    {
        private ApplicationDbContext db;
        public PersonageDataServices(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<PersonageData> GetAllPersonages()
        {
            return db.Personages.ToList();
        }

        //получаем по id
        public async Task<PersonageData> GetPersonageByIdAsync(int? id)
        {
            var personage = await db.Personages
                .FirstOrDefaultAsync(m => m.Id == id);
            return personage;

        }
        public void SavePersonage(PersonageData personage)
        {
                db.Personages.Add(personage);
                db.Entry(personage).State = EntityState.Modified;
            db.SaveChanges();
        }

        public async Task DeletePersonageAsync(int id)
        {
            var personage = await db.Personages.FindAsync(id);
            db.Personages.Remove(personage);
            await db.SaveChangesAsync();
        }

    }
}
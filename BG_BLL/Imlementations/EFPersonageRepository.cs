using BG_BLL.Interfaces;
using BrowserGame.Data;
using BrowserGame.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //if (includeMaterials)
            //    return context.Set<Personage>().Include(x => x.Materials).AsNoTracking().ToList();
            //else
            return context.Personages.ToList();
        }
        
        //получаем по id
       public Personage GetPersonageById(int Id)
        {
            //if (includeMaterials)
            //    return context.Set<Personage>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            //else
                return context.Personages.FirstOrDefault(x => x.Id == Id);
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
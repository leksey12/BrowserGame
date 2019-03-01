using BG_BLL.Interfaces;
using BG_DAL.Entityes;
using BrowserGame.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BG_BLL.Imlementations
{
  public  class EFApplicationUserRepository : IApplicationUser
    {
        private ApplicationDbContext context;
        public EFApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ApplicationUser> GetAllApplicationUsers()
        {
            //if (includeMaterials)
            //    return context.Set<Personage>().Include(x => x.Materials).AsNoTracking().ToList();
            //else
            return context.Users.ToList();
        }

        //получаем по id
        public ApplicationUser GetApplicationUserById(int Id)
        {
            //if (includeMaterials)
            //    return context.Set<Personage>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            //else
            return context.Users.FirstOrDefault();
        }

        public void SaveApplicationUser(ApplicationUser user)
        {
            if (user.Id == null)
                context.Users.Add(user);
            else
                context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteApplicationUser(ApplicationUser user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
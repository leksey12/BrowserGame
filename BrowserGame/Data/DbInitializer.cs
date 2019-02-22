using BrowserGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Personages.Any())
            {
                return;   // DB has been seeded
            }

            var usersLogin = new Personage[]
            {
            new Personage{Name="Alexander",History="Живет футболом",Possession="Нападающий",Category="Лига Европы",Capital="700000",Id=1},
            new Personage{Name="Roman",History="Любит Деньги",Possession="Защитник",Category="Лига Европы",Capital="500000",Id=2},
            };
            foreach (Personage s in usersLogin)
            {
                context.Personages.Add(s);
            }
            context.SaveChanges();
            
        }
    }
}

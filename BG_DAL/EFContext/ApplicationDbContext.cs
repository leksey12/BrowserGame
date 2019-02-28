using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BG_DAL.Entityes;
using BrowserGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BrowserGame.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Personage> Personages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /// <summary>
        /// Для миграции
        /// </summary>
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(@"User ID = postgres;Password=aleksey;Server=localhost;Port=5432;Database=CoreGame;Integrated Security=true; Pooling=true;", b => b.MigrationsAssembly("BG_DAL"));
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    }
}
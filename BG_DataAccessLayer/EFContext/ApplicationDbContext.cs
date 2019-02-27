using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BrowserGame.Models;
using Microsoft.EntityFrameworkCore;

namespace BrowserGame.Data
{
    public class ApplicationUser : IdentityUser
    {

        [DisplayName("Имя")]
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

       
            public  DbSet<Personage> Personages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Personage>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}

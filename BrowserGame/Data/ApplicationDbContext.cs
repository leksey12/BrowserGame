using System;
using System.Collections.Generic;
using System.Text;
using BrowserGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrowserGame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public  DbSet<Personage> Personages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Personage>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}

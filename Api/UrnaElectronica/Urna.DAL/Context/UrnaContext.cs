using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Urna.DAL.Context
{
    public class UrnaContext : IdentityDbContext
    {
        public UrnaContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conecction = "host=localhost;port=5432;database=urnaOple;username=postgres;password=oscarin99";
                optionsBuilder.UseNpgsql(conecction);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
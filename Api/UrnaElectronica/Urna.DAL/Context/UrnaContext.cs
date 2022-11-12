using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Urna.DAL.Entities;

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
            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK_tbConfiguracion");

                entity.ToTable("configuracion");

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .UseIdentityByDefaultColumn();

                entity.Property(e => e.Configuraciones)
                      .HasColumnName("configuracion")
                      .HasColumnType("jsonb");
            });

        }

        #region DBSETS

        public virtual DbSet<Configuracion> Configuracion { get; set; }

        #endregion
    }
}
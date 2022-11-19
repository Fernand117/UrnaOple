using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Urna.DAL.Entities;

namespace Urna.DAL.Context
{
    public class UrnaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO: CAMBIO DE CONTRASEÑA DE LA DB A LA DE FERNANDO
                //var conecction = "host=localhost;port=5432;database=urnaOple;username=postgres;password=Master117+";
                var conecction = "host=localhost;port=5432;database=urnaOple;username=postgres;password=12345";
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

                entity.ToTable("Configuracion");

                entity.Property(e => e.Id)
                      .HasColumnName("Id")
                      .UseIdentityByDefaultColumn();

                entity.Property(e => e.Configuraciones)
                      .HasColumnName("Configuracion")
                      .HasColumnType("jsonb");
            });

            modelBuilder.Entity<ResultadosVotacion>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_tbResultados");

                entity.ToTable("Resultados");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityByDefaultColumn();

                entity.Property(e => e.Resultados)
                    .HasColumnName("Resultados")
                    .HasColumnType("jsonb");
            });

        }

        #region DBSETS

        public virtual DbSet<Configuracion> Configuracion { get; set; }
        
        public virtual DbSet<ResultadosVotacion> Resultados { get; set; }

        #endregion
    }
}

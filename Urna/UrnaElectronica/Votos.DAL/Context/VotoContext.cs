using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Votos.DAL.Entities.Ayuntamientos;
using Votos.DAL.Entities.Diputaciones;
using Votos.DAL.Entities.Gubernaturas;

namespace Votos.DAL.Context
{
    public class VotoContext : DbContext
    {
        public VotoContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = "host=localhost;port=5432;database=urnaVotos;username=postgres;password=oscarin99";
                optionsBuilder.UseNpgsql(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ayuntamiento>(entity =>
            {
                entity.HasKey(a => a.Id)
                      .HasName("PK_tbAyuntamiento");

                entity.ToTable("ayuntamiento");

                entity.Property(a => a.Id)
                      .HasColumnName("id")
                      .UseIdentityByDefaultColumn();

                entity.Property(a => a.Partido)
                      .HasColumnName("partidos");

                entity.Property(a => a.Voto)
                      .HasColumnName("votos");
            });

            modelBuilder.Entity<Gubernatura>(entity =>
            {
                entity.HasKey(g => g.Id)
                      .HasName("PK_tbGubernatura");

                entity.ToTable("gubernatura");

                entity.Property(g => g.Id)
                      .HasColumnName("id")
                      .UseIdentityByDefaultColumn();

                entity.Property(g => g.Partido)
                      .HasColumnName("partidos");

                entity.Property(g => g.Voto)
                      .HasColumnName("votos");
            });

            modelBuilder.Entity<Diputacion>(entity =>
            {
                entity.HasKey(d => d.Id)
                      .HasName("PK_tbDiputacion");

                entity.ToTable("diputacion");

                entity.Property(d => d.Id)
                      .HasColumnName("id")
                      .UseIdentityByDefaultColumn();

                entity.Property(d => d.Partido)
                      .HasColumnName("partidos");

                entity.Property(d => d.Voto)
                      .HasColumnName("votos");
            });
        }

        #region DBSETS

        public virtual DbSet<Ayuntamiento> Ayuntamientos { get; set; }

        public virtual DbSet<Gubernatura> Gubernaturas { get; set; }

        public virtual DbSet<Diputacion> Diputaciones { get; set; }

        #endregion
    }
}

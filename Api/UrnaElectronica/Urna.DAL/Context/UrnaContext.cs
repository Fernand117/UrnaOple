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
            modelBuilder.Entity<Eleccion>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK_tbElecciones");

                entity.ToTable("elecciones");

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .UseIdentityByDefaultColumn();

                entity.Property(e => e.TipoEleccion)
                     .HasColumnName("tipoEleccion")
                     .HasMaxLength(50);

                entity.Property(e => e.Presidente)
                      .HasColumnName("presidente")
                      .HasMaxLength(50);

                entity.Property(e => e.Secretario)
                      .HasColumnName("secretario")
                      .HasMaxLength(50);

                entity.Property(e => e.PrimerEscrutador)
                      .HasColumnName("primerEscrutador")
                      .HasMaxLength(50);

                entity.Property(e => e.SegundoEscrutador)
                      .HasColumnName("segundoEscrutador")
                      .HasMaxLength(50);

                entity.Property(e => e.CantidadBoletas)
                      .HasColumnName("cantidadBoletas")
                      .HasMaxLength(5);

                entity.Property(e => e.Entidad)
                      .HasColumnName("entidad")
                      .HasMaxLength(20);

                entity.Property(e => e.Distrito)
                      .HasColumnName("distrito")
                      .HasMaxLength(20);

                entity.Property(e => e.Municipio)
                      .HasColumnName("municipio")
                      .HasMaxLength(30);

                entity.Property(e => e.SeccionElectoral)
                      .HasColumnName("seccionElectoral")
                      .HasMaxLength(20);

                entity.Property(e => e.TipoCasilla)
                      .HasColumnName("tipoCasilla")
                      .HasMaxLength(20);

                entity.Property(e => e.Folio)
                      .HasColumnName("folio")
                      .HasMaxLength(20);
            });

        }

        #region DBSETS

        public virtual DbSet<Eleccion> Eleccions { get; set; }

        #endregion
    }
}
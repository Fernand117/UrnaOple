using Microsoft.EntityFrameworkCore;
using Votos.DAL.Entities.Ayuntamientos;
using Votos.DAL.Entities.ConsultasPopulares;
using Votos.DAL.Entities.ContadorBoletas;
using Votos.DAL.Entities.Diputaciones;
using Votos.DAL.Entities.Escolares;
using Votos.DAL.Entities.Gubernaturas;
using Votos.DAL.Entities.MecanismoPresbicito;
using Votos.DAL.Entities.MecanismoReferendum;

namespace Votos.DAL.Context
{
    public class VotoContext : DbContext
    {
        public VotoContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //TODO: CAMBIE LA CONTRASEÑA DEL CONTEXT A LA DE MI DB FERNANDO
                //var connection = "host=localhost;port=5432;database=urnaVotos;username=postgres;password=Master117+";

                var connection = "host=localhost;port=5432;database=urnaVotos;username=postgres;password=12345";

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

                entity.Property(a => a.Tipo)
                      .HasColumnName("tipo");
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

            modelBuilder.Entity<Consulta>(entity =>
            {
                  entity.HasKey(c => c.Id)
                        .HasName("PK_tbConsulta");

                  //TODO: Continuar aquí programando los modelos
                  entity.ToTable("consulta");
                  
                  entity.Property(c => c.Id)
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                  entity.Property(c => c.Pregunta)
                        .HasColumnName("pregunta");

                  entity.Property(c => c.RespuestaSi)
                        .HasColumnName("si");

                  entity.Property(c => c.RespuestaNo)
                        .HasColumnName("no");
            });

            modelBuilder.Entity<Presbicitos>(entity =>
            {
                  entity.HasKey(p => p.Id)
                        .HasName("PK_tbPresbicito");

                  entity.ToTable("presbicito");

                  entity.Property(p => p.Id)
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                  entity.Property(p => p.Pregunta)
                        .HasColumnName("pregunta");

                  entity.Property(p => p.RespuestaSi)
                        .HasColumnName("si");

                  entity.Property(p => p.RespuestaNo)
                        .HasColumnName("no");
            });

            modelBuilder.Entity<Referendums>(entity =>
            {
                  entity.HasKey(r => r.Id)
                        .HasName("PK_tbReferendum");

                  entity.ToTable("referendum");

                  entity.Property(r => r.Id)
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                  entity.Property(r => r.Pregunta)
                        .HasColumnName("pregunta");

                  entity.Property(r => r.RespuestaSi)
                        .HasColumnName("si");

                  entity.Property(r => r.RespuestaNo)
                        .HasColumnName("no");
            });

            modelBuilder.Entity<Escolar>(entity =>
            {
                  entity.HasKey(e => e.Id)
                        .HasName("PK_tbEscolares");

                  entity.ToTable("escolares");

                  entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                  entity.Property(e => e.Partido)
                        .HasColumnName("partido");

                  entity.Property(e => e.Voto)
                        .HasColumnName("voto");
            });

            modelBuilder.Entity<BoletasContador>(entity =>
            {
                  entity.HasKey(b => b.Id)
                        .HasName("PK_tbBoletas");

                  entity.ToTable("boletas");

                  entity.Property(b => b.Id)
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                  entity.Property(b => b.TipoEleccion)
                        .HasColumnName("tipoeleccion");

                  entity.Property(b => b.CantidadBoletas)
                        .HasColumnName("cantidadboletas");
            });
        }

      #region DBSETS

        public virtual DbSet<Ayuntamiento> Ayuntamientos { get; set; }

        public virtual DbSet<Gubernatura> Gubernaturas { get; set; }

        public virtual DbSet<Diputacion> Diputaciones { get; set; }
        
        public virtual DbSet<Consulta> ConsultasPopulares { get; set; }
        
        public virtual DbSet<Presbicitos> Presbicitos { get; set; }
        
        public virtual DbSet<Referendums> Referendums { get; set; }
        
        public virtual DbSet<Escolar> Escolares { get; set; }
        
        public virtual DbSet<BoletasContador> Boletas { get; set; }

        #endregion
    }
}

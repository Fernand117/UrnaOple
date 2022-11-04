﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Votos.DAL.Context;

namespace Votos.DAL.Migrations
{
    [DbContext(typeof(VotoContext))]
    [Migration("20221104003101_update_contador")]
    partial class update_contador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Votos.DAL.Entities.Ayuntamientos.Ayuntamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Partido")
                        .HasColumnName("partidos")
                        .HasColumnType("text");

                    b.Property<string>("Voto")
                        .HasColumnName("votos")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbAyuntamiento");

                    b.ToTable("ayuntamiento");
                });

            modelBuilder.Entity("Votos.DAL.Entities.ConsultasPopulares.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pregunta")
                        .HasColumnName("pregunta")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaNo")
                        .HasColumnName("no")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaSi")
                        .HasColumnName("si")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbConsulta");

                    b.ToTable("consulta");
                });

            modelBuilder.Entity("Votos.DAL.Entities.ContadorBoletas.BoletasContador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CantidadBoletas")
                        .HasColumnName("cantidadboletas")
                        .HasColumnType("text");

                    b.Property<string>("TipoEleccion")
                        .HasColumnName("tipoeleccion")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbBoletas");

                    b.ToTable("boletas");
                });

            modelBuilder.Entity("Votos.DAL.Entities.Diputaciones.Diputacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Partido")
                        .HasColumnName("partidos")
                        .HasColumnType("text");

                    b.Property<string>("Voto")
                        .HasColumnName("votos")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbDiputacion");

                    b.ToTable("diputacion");
                });

            modelBuilder.Entity("Votos.DAL.Entities.Escolares.Escolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Partido")
                        .HasColumnName("partido")
                        .HasColumnType("text");

                    b.Property<string>("Voto")
                        .HasColumnName("voto")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbEscolares");

                    b.ToTable("escolares");
                });

            modelBuilder.Entity("Votos.DAL.Entities.Gubernaturas.Gubernatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Partido")
                        .HasColumnName("partidos")
                        .HasColumnType("text");

                    b.Property<string>("Voto")
                        .HasColumnName("votos")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbGubernatura");

                    b.ToTable("gubernatura");
                });

            modelBuilder.Entity("Votos.DAL.Entities.MecanismoPresbicito.Presbicitos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pregunta")
                        .HasColumnName("pregunta")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaNo")
                        .HasColumnName("no")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaSi")
                        .HasColumnName("si")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbPresbicito");

                    b.ToTable("presbicito");
                });

            modelBuilder.Entity("Votos.DAL.Entities.MecanismoReferendum.Referendums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pregunta")
                        .HasColumnName("pregunta")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaNo")
                        .HasColumnName("no")
                        .HasColumnType("text");

                    b.Property<string>("RespuestaSi")
                        .HasColumnName("si")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_tbReferendum");

                    b.ToTable("referendum");
                });
#pragma warning restore 612, 618
        }
    }
}

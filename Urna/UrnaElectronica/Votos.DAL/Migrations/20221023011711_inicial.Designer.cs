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
    [Migration("20221023011711_inicial")]
    partial class inicial
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
#pragma warning restore 612, 618
        }
    }
}

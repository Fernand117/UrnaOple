﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Urna.DAL.Context;

namespace Urna.DAL.Migrations
{
    [DbContext(typeof(UrnaContext))]
    partial class UrnaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Urna.DAL.Entities.Configuracion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("text");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<string>("Configuraciones")
                        .HasColumnName("Configuracion")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_tbConfiguracion");

                    b.ToTable("Configuracion");
                });
#pragma warning restore 612, 618
        }
    }
}

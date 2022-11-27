using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Votos.DAL.Migrations
{
    public partial class opledb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ayuntamiento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    partidos = table.Column<string>(nullable: true),
                    votos = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAyuntamiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "boletas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoeleccion = table.Column<string>(nullable: true),
                    cantidadboletas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBoletas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consulta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pregunta = table.Column<string>(nullable: true),
                    si = table.Column<string>(nullable: true),
                    no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConsulta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "diputacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    partidos = table.Column<string>(nullable: true),
                    votos = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDiputacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "escolares",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    partido = table.Column<string>(nullable: true),
                    voto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEscolares", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gubernatura",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    partidos = table.Column<string>(nullable: true),
                    votos = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbGubernatura", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "presbicito",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pregunta = table.Column<string>(nullable: true),
                    si = table.Column<string>(nullable: true),
                    no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPresbicito", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "referendum",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pregunta = table.Column<string>(nullable: true),
                    si = table.Column<string>(nullable: true),
                    no = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbReferendum", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ayuntamiento");

            migrationBuilder.DropTable(
                name: "boletas");

            migrationBuilder.DropTable(
                name: "consulta");

            migrationBuilder.DropTable(
                name: "diputacion");

            migrationBuilder.DropTable(
                name: "escolares");

            migrationBuilder.DropTable(
                name: "gubernatura");

            migrationBuilder.DropTable(
                name: "presbicito");

            migrationBuilder.DropTable(
                name: "referendum");
        }
    }
}

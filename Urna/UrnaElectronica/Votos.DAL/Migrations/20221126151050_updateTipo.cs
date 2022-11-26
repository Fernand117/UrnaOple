using Microsoft.EntityFrameworkCore.Migrations;

namespace Votos.DAL.Migrations
{
    public partial class updateTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "gubernatura",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "diputacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "ayuntamiento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "gubernatura");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "diputacion");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "ayuntamiento");
        }
    }
}

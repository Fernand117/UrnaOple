using Microsoft.EntityFrameworkCore.Migrations;

namespace Urna.DAL.Migrations
{
    public partial class update_dbOple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "configuracion",
                newName: "Codigo");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "configuracion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "configuracion");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "configuracion",
                newName: "codigo");
        }
    }
}

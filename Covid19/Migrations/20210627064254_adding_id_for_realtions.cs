using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Migrations
{
    public partial class adding_id_for_realtions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCiudadano",
                table: "ControlVacunas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idDireccion",
                table: "ControlVacunas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCiudadano",
                table: "ControlVacunas");

            migrationBuilder.DropColumn(
                name: "idDireccion",
                table: "ControlVacunas");
        }
    }
}

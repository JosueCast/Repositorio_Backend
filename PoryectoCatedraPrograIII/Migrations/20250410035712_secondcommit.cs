using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoryectoCatedraPrograIII.Migrations
{
    /// <inheritdoc />
    public partial class secondcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetodoRegistro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Tiendas",
                newName: "HorarioInicio");

            migrationBuilder.AddColumn<string>(
                name: "HoararioSalida",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoararioSalida",
                table: "Tiendas");

            migrationBuilder.RenameColumn(
                name: "HorarioInicio",
                table: "Tiendas",
                newName: "Horario");

            migrationBuilder.AddColumn<string>(
                name: "MetodoRegistro",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Productos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

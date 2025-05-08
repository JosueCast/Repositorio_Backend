using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoryectoCatedraPrograIII.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTiendaModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoararioSalida",
                table: "Tiendas",
                newName: "HorarioSalida");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioSalida",
                table: "Tiendas",
                newName: "HoararioSalida");
        }
    }
}

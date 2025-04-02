using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoryectoCatedraPrograIII.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "Usuarios");
        }
    }
}

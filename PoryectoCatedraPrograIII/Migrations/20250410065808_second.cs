using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoryectoCatedraPrograIII.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiendas_TipoTiendas_TipoTiendasId",
                table: "Tiendas");

            migrationBuilder.DropIndex(
                name: "IX_Tiendas_TipoTiendasId",
                table: "Tiendas");

            migrationBuilder.DropColumn(
                name: "TipoTiendasId",
                table: "Tiendas");

            migrationBuilder.AlterColumn<string>(
                name: "Slogan",
                table: "Tiendas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaginaWeb",
                table: "Tiendas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroContacto",
                table: "Tiendas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HorarioInicio",
                table: "Tiendas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HoararioSalida",
                table: "Tiendas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FotoFachada",
                table: "Tiendas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FacebookContacto",
                table: "Tiendas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_idTipoTiendas",
                table: "Tiendas",
                column: "idTipoTiendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiendas_TipoTiendas_idTipoTiendas",
                table: "Tiendas",
                column: "idTipoTiendas",
                principalTable: "TipoTiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiendas_TipoTiendas_idTipoTiendas",
                table: "Tiendas");

            migrationBuilder.DropIndex(
                name: "IX_Tiendas_idTipoTiendas",
                table: "Tiendas");

            migrationBuilder.AlterColumn<string>(
                name: "Slogan",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PaginaWeb",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroContacto",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "HorarioInicio",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "HoararioSalida",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FotoFachada",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookContacto",
                table: "Tiendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "TipoTiendasId",
                table: "Tiendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_TipoTiendasId",
                table: "Tiendas",
                column: "TipoTiendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiendas_TipoTiendas_TipoTiendasId",
                table: "Tiendas",
                column: "TipoTiendasId",
                principalTable: "TipoTiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

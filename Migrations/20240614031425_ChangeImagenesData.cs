using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubee.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagenesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoId",
                table: "ClasificadoImagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoRefId",
                table: "ClasificadoImagenes");

            migrationBuilder.DropIndex(
                name: "IX_ClasificadoImagenes_ClasificadoRefId",
                table: "ClasificadoImagenes");

            migrationBuilder.DropColumn(
                name: "ClasificadoRefId",
                table: "ClasificadoImagenes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TiposPropiedades",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClasificadoId",
                table: "ClasificadoImagenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoId",
                table: "ClasificadoImagenes",
                column: "ClasificadoId",
                principalTable: "Clasificados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoId",
                table: "ClasificadoImagenes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TiposPropiedades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ClasificadoId",
                table: "ClasificadoImagenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClasificadoRefId",
                table: "ClasificadoImagenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClasificadoImagenes_ClasificadoRefId",
                table: "ClasificadoImagenes",
                column: "ClasificadoRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoId",
                table: "ClasificadoImagenes",
                column: "ClasificadoId",
                principalTable: "Clasificados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificadoImagenes_Clasificados_ClasificadoRefId",
                table: "ClasificadoImagenes",
                column: "ClasificadoRefId",
                principalTable: "Clasificados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

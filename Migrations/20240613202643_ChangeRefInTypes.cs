using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubee.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRefInTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionId",
                table: "Clasificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionRefId",
                table: "Clasificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadId",
                table: "Clasificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadRefId",
                table: "Clasificados");

            migrationBuilder.DropIndex(
                name: "IX_Clasificados_TipoOperacionRefId",
                table: "Clasificados");

            migrationBuilder.DropIndex(
                name: "IX_Clasificados_TipoPropiedadRefId",
                table: "Clasificados");

            migrationBuilder.DropColumn(
                name: "TipoOperacionRefId",
                table: "Clasificados");

            migrationBuilder.DropColumn(
                name: "TipoPropiedadRefId",
                table: "Clasificados");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionId",
                table: "Clasificados",
                column: "TipoOperacionId",
                principalTable: "TiposOperaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadId",
                table: "Clasificados",
                column: "TipoPropiedadId",
                principalTable: "TiposPropiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionId",
                table: "Clasificados");

            migrationBuilder.DropForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadId",
                table: "Clasificados");

            migrationBuilder.AddColumn<int>(
                name: "TipoOperacionRefId",
                table: "Clasificados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPropiedadRefId",
                table: "Clasificados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoOperacionRefId",
                table: "Clasificados",
                column: "TipoOperacionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoPropiedadRefId",
                table: "Clasificados",
                column: "TipoPropiedadRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionId",
                table: "Clasificados",
                column: "TipoOperacionId",
                principalTable: "TiposOperaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposOperaciones_TipoOperacionRefId",
                table: "Clasificados",
                column: "TipoOperacionRefId",
                principalTable: "TiposOperaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadId",
                table: "Clasificados",
                column: "TipoPropiedadId",
                principalTable: "TiposPropiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clasificados_TiposPropiedades_TipoPropiedadRefId",
                table: "Clasificados",
                column: "TipoPropiedadRefId",
                principalTable: "TiposPropiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

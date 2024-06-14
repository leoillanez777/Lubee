using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Lubee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposOperaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOperaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPropiedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clasificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPropiedadRefId = table.Column<int>(type: "int", nullable: false),
                    TipoPropiedadId = table.Column<int>(type: "int", nullable: false),
                    TipoOperacionRefId = table.Column<int>(type: "int", nullable: false),
                    TipoOperacionId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ambientes = table.Column<int>(type: "int", nullable: false),
                    M2 = table.Column<int>(type: "int", nullable: false),
                    Antiguedad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<Geometry>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clasificados_TiposOperaciones_TipoOperacionId",
                        column: x => x.TipoOperacionId,
                        principalTable: "TiposOperaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasificados_TiposOperaciones_TipoOperacionRefId",
                        column: x => x.TipoOperacionRefId,
                        principalTable: "TiposOperaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clasificados_TiposPropiedades_TipoPropiedadId",
                        column: x => x.TipoPropiedadId,
                        principalTable: "TiposPropiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasificados_TiposPropiedades_TipoPropiedadRefId",
                        column: x => x.TipoPropiedadRefId,
                        principalTable: "TiposPropiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClasificadoImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasificadoRefId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ClasificadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificadoImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClasificadoImagenes_Clasificados_ClasificadoId",
                        column: x => x.ClasificadoId,
                        principalTable: "Clasificados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClasificadoImagenes_Clasificados_ClasificadoRefId",
                        column: x => x.ClasificadoRefId,
                        principalTable: "Clasificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasificadoImagenes_ClasificadoId",
                table: "ClasificadoImagenes",
                column: "ClasificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificadoImagenes_ClasificadoRefId",
                table: "ClasificadoImagenes",
                column: "ClasificadoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoOperacionId",
                table: "Clasificados",
                column: "TipoOperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoOperacionRefId",
                table: "Clasificados",
                column: "TipoOperacionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoPropiedadId",
                table: "Clasificados",
                column: "TipoPropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificados_TipoPropiedadRefId",
                table: "Clasificados",
                column: "TipoPropiedadRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasificadoImagenes");

            migrationBuilder.DropTable(
                name: "Clasificados");

            migrationBuilder.DropTable(
                name: "TiposOperaciones");

            migrationBuilder.DropTable(
                name: "TiposPropiedades");
        }
    }
}

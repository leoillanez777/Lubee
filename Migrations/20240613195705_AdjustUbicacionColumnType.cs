using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubee.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUbicacionColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Clasificados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Clasificados");
        }
    }
}

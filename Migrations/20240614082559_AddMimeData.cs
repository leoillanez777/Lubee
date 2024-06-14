using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lubee.Migrations
{
    /// <inheritdoc />
    public partial class AddMimeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mime",
                table: "ClasificadoImagenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mime",
                table: "ClasificadoImagenes");
        }
    }
}

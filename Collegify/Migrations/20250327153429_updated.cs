using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collegify.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Professors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Grades",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "id");
        }
    }
}

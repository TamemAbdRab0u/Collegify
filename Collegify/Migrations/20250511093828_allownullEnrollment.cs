using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collegify.Migrations
{
    /// <inheritdoc />
    public partial class allownullEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Enrollment_EnrollmentID",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "EnrollmentID",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Enrollment_EnrollmentID",
                table: "Grades",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Enrollment_EnrollmentID",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "EnrollmentID",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Enrollment_EnrollmentID",
                table: "Grades",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

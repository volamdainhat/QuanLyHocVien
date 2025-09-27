using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SemesterId",
                table: "Grades",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Semesters_SemesterId",
                table: "Grades",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Semesters_SemesterId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SemesterId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Grades");
        }
    }
}

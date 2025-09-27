using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGrades2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeType",
                table: "Grades",
                type: "TEXT",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeType",
                table: "Grades");
        }
    }
}

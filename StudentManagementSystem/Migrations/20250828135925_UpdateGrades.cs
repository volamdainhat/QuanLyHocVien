using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalStudents",
                table: "Classes",
                newName: "MaxStudents");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ClassId",
                table: "Trainees",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_ClassId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "MaxStudents",
                table: "Classes",
                newName: "TotalStudents");
        }
    }
}

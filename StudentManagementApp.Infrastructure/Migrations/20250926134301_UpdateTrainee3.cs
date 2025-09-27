using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainee3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Trainees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Trainees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Classes_ClassId",
                table: "Trainees",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

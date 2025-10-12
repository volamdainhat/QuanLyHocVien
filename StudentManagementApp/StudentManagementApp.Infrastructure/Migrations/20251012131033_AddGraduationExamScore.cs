using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGraduationExamScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GraduationExamScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    GraduationExamType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
                    GradeType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationExamScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationExamScores_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraduationScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
                    GraduationType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationScores_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Code", "Name", "SortOrder", "Type" },
                values: new object[] { "thuc_hanh", "Thi Thực hành", 1, "GraduationExamType" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "ParentId", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 96, "ly_thuyet", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Lý thuyết chuyên môn", 0, 2, "GraduationExamType" },
                    { 97, "chinh_tri", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Chính trị", 0, 3, "GraduationExamType" },
                    { 98, "quan_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Quân sự chung", 0, 4, "GraduationExamType" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduationExamScores_TraineeId",
                table: "GraduationExamScores",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationScores_TraineeId",
                table: "GraduationScores",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraduationExamScores");

            migrationBuilder.DropTable(
                name: "GraduationScores");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Code", "Name", "SortOrder", "Type" },
                values: new object[] { "tot_nghiep", "Thi xét tốt nghiệp", 4, "ExamType" });
        }
    }
}

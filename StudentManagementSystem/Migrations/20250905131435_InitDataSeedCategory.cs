using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitDataSeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "Description", "IsActive", "Name", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 1, "STUDENT", null, true, "Học viên", 1, "Role" },
                    { 2, "SQUAD_LEADER", null, true, "Tiểu đội trưởng", 2, "Role" },
                    { 3, "CLASS_MONITOR", null, true, "Lớp trưởng", 3, "Role" },
                    { 4, "STUDY_ASSISTANT", null, true, "Lớp phó học tập", 4, "Role" },
                    { 5, "LOGISTICS_ASSISTANT", null, true, "Lớp phó hậu cần", 5, "Role" },
                    { 6, "TEST_15M", null, true, "Kiểm tra 15 phút", 1, "ExamType" },
                    { 7, "TEST_1H", null, true, "Kiểm tra 1 tiết", 2, "ExamType" },
                    { 8, "FINAL", null, true, "Thi cuối môn", 3, "ExamType" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

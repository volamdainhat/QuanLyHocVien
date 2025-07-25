using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyHocVien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTraineeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "AverageScore", "ClassId", "DayOfBirth", "EnlistmentDate", "FatherFullName", "FatherPhoneNumber", "FullName", "MotherFullName", "MotherPhoneNumber", "PhoneNumber", "Ranking", "Role" },
                values: new object[,]
                {
                    { 1, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nguyễn Văn A", null, null, null, "Giỏi", "Học viên" },
                    { 2, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Trần Thị B", null, null, null, "Khá", "Học viên" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

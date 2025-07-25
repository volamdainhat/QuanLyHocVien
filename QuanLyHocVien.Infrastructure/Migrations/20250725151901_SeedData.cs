using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyHocVien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "AverageScore", "ClassId", "DayOfBirth", "EnlistmentDate", "FatherFullName", "FatherPhoneNumber", "FullName", "MotherFullName", "MotherPhoneNumber", "PhoneNumber", "Ranking", "Role" },
                values: new object[,]
                {
                    { 3, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lê Văn C", null, null, null, "Khá", "Học viên" },
                    { 4, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Phạm Thị D", null, null, null, "Trung bình", "Học viên" },
                    { 5, null, 2, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ngô Văn E", null, null, null, "Giỏi", "Học viên" },
                    { 6, null, 2, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Đinh Thị F", null, null, null, "Khá", "Học viên" },
                    { 7, null, 2, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Hoàng Văn G", null, null, null, "Giỏi", "Học viên" },
                    { 8, null, 3, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Trịnh Thị H", null, null, null, "Trung bình", "Học viên" },
                    { 9, null, 3, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lý Văn I", null, null, null, "Khá", "Học viên" },
                    { 10, null, 3, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bùi Thị K", null, null, null, "Giỏi", "Học viên" },
                    { 11, null, 4, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Vũ Văn L", null, null, null, "Yếu", "Học viên" },
                    { 12, null, 4, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nguyễn Thị M", null, null, null, "Trung bình", "Học viên" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "AverageScore", "ClassId", "DayOfBirth", "EnlistmentDate", "FatherFullName", "FatherPhoneNumber", "FullName", "MotherFullName", "MotherPhoneNumber", "PhoneNumber", "Ranking", "Role" },
                values: new object[,]
                {
                    { 1, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nguyễn Văn A", null, null, null, "Giỏi", "Học viên" },
                    { 2, null, 1, null, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Trần Thị B", null, null, null, "Khá", "Học viên" }
                });
        }
    }
}

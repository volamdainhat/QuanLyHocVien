using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataSeed_17_9_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "ParentId", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 57, "mam_non", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Mầm non", 0, 1, "EducationLevel" },
                    { 58, "tieu_hoc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tiểu học", 0, 2, "EducationLevel" },
                    { 59, "thcs", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung học cơ sở", 0, 3, "EducationLevel" },
                    { 60, "thpt", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung học phổ thông", 0, 4, "EducationLevel" },
                    { 61, "trung_cap", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung cấp", 0, 5, "EducationLevel" },
                    { 62, "cao_dang", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Cao đẳng", 0, 6, "EducationLevel" },
                    { 63, "dai_hoc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại học", 0, 7, "EducationLevel" },
                    { 64, "thac_si", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thạc sĩ", 0, 8, "EducationLevel" },
                    { 65, "tien_si", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tiến sĩ", 0, 9, "EducationLevel" },
                    { 66, "pho_giao_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Phó Giáo sư", 0, 10, "EducationLevel" },
                    { 67, "giao_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Giáo sư", 0, 11, "EducationLevel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);
        }
    }
}

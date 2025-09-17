using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DayOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdentityCard = table.Column<string>(type: "TEXT", nullable: false),
                    Ethnicity = table.Column<string>(type: "TEXT", nullable: false),
                    PlaceOfOrigin = table.Column<string>(type: "TEXT", nullable: false),
                    PlaceOfPermanentResidence = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ProvinceOfEnlistment = table.Column<string>(type: "TEXT", nullable: false),
                    EducationalLevel = table.Column<string>(type: "TEXT", nullable: false),
                    AddressForCorrespondence = table.Column<string>(type: "TEXT", nullable: false),
                    EnlistmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MilitaryRank = table.Column<string>(type: "TEXT", nullable: false),
                    HealthStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AverageScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    FatherFullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FatherPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    MotherFullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    MotherPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    MeritScore = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 1, "hoc_vien", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Học viên", 1, "Role" },
                    { 2, "tieu_truong", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tiểu đội trưởng", 2, "Role" },
                    { 3, "lop_truong", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp trưởng", 3, "Role" },
                    { 4, "hoc_tap", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp phó học tập", 4, "Role" },
                    { 5, "hau_can", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp phó hậu cần", 5, "Role" },
                    { 6, "kt_15p", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Kiểm tra 15 phút", 1, "ExamType" },
                    { 7, "kt_1t", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Kiểm tra 1 tiết", 2, "ExamType" },
                    { 8, "thi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi cuối môn", 3, "ExamType" },
                    { 9, "B2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Binh nhì", 1, "MilitaryRank" },
                    { 10, "B1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Binh nhất", 2, "MilitaryRank" },
                    { 11, "H1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Hạ sĩ", 3, "MilitaryRank" },
                    { 12, "H2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung sĩ", 4, "MilitaryRank" },
                    { 13, "H3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng sĩ", 5, "MilitaryRank" },
                    { 14, "1/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thiếu úy", 6, "MilitaryRank" },
                    { 15, "2/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung úy", 7, "MilitaryRank" },
                    { 16, "3/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng úy", 8, "MilitaryRank" },
                    { 17, "4/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại úy", 9, "MilitaryRank" },
                    { 18, "1//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thiếu tá", 10, "MilitaryRank" },
                    { 19, "2//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung tá", 11, "MilitaryRank" },
                    { 20, "3//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng tá", 12, "MilitaryRank" },
                    { 21, "4//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại tá", 13, "MilitaryRank" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolYearId",
                table: "Classes",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ClassId",
                table: "Trainees",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "SchoolYears");
        }
    }
}

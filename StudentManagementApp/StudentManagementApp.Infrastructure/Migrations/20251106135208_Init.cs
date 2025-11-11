using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "RollCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RollCaller = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    Present = table.Column<int>(type: "INTEGER", nullable: false),
                    Absent = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollCalls", x => x.Id);
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
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Coefficient = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Room = table.Column<string>(type: "TEXT", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
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
                    FatherFullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FatherPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    MotherFullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    MotherPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    SemesterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamType = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<decimal>(type: "TEXT", nullable: false),
                    GradeType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Misconducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misconducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Misconducts_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PracticePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Point = table.Column<decimal>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticePoints_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectAverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
                    GradeType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectAverages_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAverages_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeAverageScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SemesterId = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    GradeType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeAverageScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraineeAverageScores_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeAverageScores_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyCritiques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PoliticalAttitude = table.Column<string>(type: "TEXT", nullable: true),
                    PAScore = table.Column<int>(type: "INTEGER", nullable: false),
                    StudyMotivation = table.Column<string>(type: "TEXT", nullable: true),
                    SMScore = table.Column<int>(type: "INTEGER", nullable: false),
                    EthicsLifestyle = table.Column<string>(type: "TEXT", nullable: true),
                    ELScore = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplineAwareness = table.Column<string>(type: "TEXT", nullable: true),
                    DAScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicResult = table.Column<string>(type: "TEXT", nullable: true),
                    ARScore = table.Column<int>(type: "INTEGER", nullable: false),
                    ResearchActivity = table.Column<string>(type: "TEXT", nullable: true),
                    RAScore = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    WeekDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyCritiques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyCritiques_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "ParentId", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 1, "hoc_vien", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Học viên", 0, 1, "Role" },
                    { 2, "tieu_truong", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tiểu đội trưởng", 0, 2, "Role" },
                    { 3, "lop_truong", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp trưởng", 0, 3, "Role" },
                    { 4, "hoc_tap", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp phó học tập", 0, 4, "Role" },
                    { 5, "hau_can", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Lớp phó hậu cần", 0, 5, "Role" },
                    { 6, "kt_15p", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Kiểm tra 15 phút", 0, 1, "ExamType" },
                    { 7, "kt_1t", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Kiểm tra 1 tiết", 0, 2, "ExamType" },
                    { 8, "thi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi cuối môn", 0, 3, "ExamType" },
                    { 9, "B2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Binh nhì", 0, 1, "MilitaryRank" },
                    { 10, "B1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Binh nhất", 0, 2, "MilitaryRank" },
                    { 11, "H1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Hạ sĩ", 0, 3, "MilitaryRank" },
                    { 12, "H2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung sĩ", 0, 4, "MilitaryRank" },
                    { 13, "H3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng sĩ", 0, 5, "MilitaryRank" },
                    { 14, "1/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thiếu úy", 0, 6, "MilitaryRank" },
                    { 15, "2/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung úy", 0, 7, "MilitaryRank" },
                    { 16, "3/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng úy", 0, 8, "MilitaryRank" },
                    { 17, "4/", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại úy", 0, 9, "MilitaryRank" },
                    { 18, "1//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thiếu tá", 0, 10, "MilitaryRank" },
                    { 19, "2//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung tá", 0, 11, "MilitaryRank" },
                    { 20, "3//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thượng tá", 0, 12, "MilitaryRank" },
                    { 21, "4//", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại tá", 0, 13, "MilitaryRank" },
                    { 22, "ha_noi_01", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Hà Nội", 0, 1, "Provinces" },
                    { 23, "cao_bang_04", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Cao Bằng", 0, 2, "Provinces" },
                    { 24, "tuyen_quang_08", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Tuyên Quang", 0, 3, "Provinces" },
                    { 25, "dien_bien_11", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Điện Biên", 0, 4, "Provinces" },
                    { 26, "lai_chau_12", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Lai Châu", 0, 5, "Provinces" },
                    { 27, "son_la_14", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Sơn La", 0, 6, "Provinces" },
                    { 28, "lao_cai_15", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Lào Cai", 0, 7, "Provinces" },
                    { 29, "thai_nguyen_19", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Thái Nguyên", 0, 8, "Provinces" },
                    { 30, "lang_son_20", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Lạng Sơn", 0, 9, "Provinces" },
                    { 31, "quang_ninh_22", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Quảng Ninh", 0, 10, "Provinces" },
                    { 32, "bac_ninh_24", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Bắc Ninh", 0, 11, "Provinces" },
                    { 33, "phu_tho_25", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Phú Thọ", 0, 12, "Provinces" },
                    { 34, "hai_phong_31", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Hải Phòng", 0, 13, "Provinces" },
                    { 35, "hung_yen_33", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Hưng Yên", 0, 14, "Provinces" },
                    { 36, "ninh_binh_37", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Ninh Bình", 0, 15, "Provinces" },
                    { 37, "thanh_hoa_38", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Thanh Hóa", 0, 16, "Provinces" },
                    { 38, "nghe_an_40", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Nghệ An", 0, 17, "Provinces" },
                    { 39, "ha_tinh_42", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Hà Tĩnh", 0, 18, "Provinces" },
                    { 40, "quang_tri_44", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Quảng Trị", 0, 19, "Provinces" },
                    { 41, "hue_46", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Huế", 0, 20, "Provinces" },
                    { 42, "da_nang_48", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Đà Nẵng", 0, 21, "Provinces" },
                    { 43, "quang_ngai_51", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Quảng Ngãi", 0, 22, "Provinces" },
                    { 44, "gia_lai_52", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Gia Lai", 0, 23, "Provinces" },
                    { 45, "khanh_hoa_56", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Khánh Hòa", 0, 24, "Provinces" },
                    { 46, "dak_lak_66", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Đắk Lắk", 0, 25, "Provinces" },
                    { 47, "lam_dong_68", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Lâm Đồng", 0, 26, "Provinces" },
                    { 48, "dong_nai_75", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Đồng Nai", 0, 27, "Provinces" },
                    { 49, "ho_chi_minh_79", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Hồ Chí Minh", 0, 28, "Provinces" },
                    { 51, "tay_ninh_80", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Tây Ninh", 0, 29, "Provinces" },
                    { 52, "dong_thap_82", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Đồng Tháp", 0, 30, "Provinces" },
                    { 53, "vinh_long_86", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Vĩnh Long", 0, 31, "Provinces" },
                    { 54, "an_giang_91", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh An Giang", 0, 32, "Provinces" },
                    { 55, "can_tho_92", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thành phố Cần Thơ", 0, 33, "Provinces" },
                    { 56, "ca_mau_96", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tỉnh Cà Mau", 0, 34, "Provinces" },
                    { 59, "thcs", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung học cơ sở", 0, 3, "EducationLevel" },
                    { 60, "thpt", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung học phổ thông", 0, 4, "EducationLevel" },
                    { 61, "trung_cap", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Trung cấp", 0, 5, "EducationLevel" },
                    { 62, "cao_dang", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Cao đẳng", 0, 6, "EducationLevel" },
                    { 63, "dai_hoc", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đại học", 0, 7, "EducationLevel" },
                    { 64, "thac_si", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thạc sĩ", 0, 8, "EducationLevel" },
                    { 65, "tien_si", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tiến sĩ", 0, 9, "EducationLevel" },
                    { 66, "pho_giao_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Phó Giáo sư", 0, 10, "EducationLevel" },
                    { 67, "giao_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Giáo sư", 0, 11, "EducationLevel" },
                    { 68, "sang", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Buổi sáng", 0, 1, "SchedulePeriod" },
                    { 69, "chieu", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Buổi chiều", 0, 2, "SchedulePeriod" },
                    { 70, "vang", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Vắng", 0, 1, "MisconductType" },
                    { 71, "vi_pham_ky_luat", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Vi phạm kỷ luật", 0, 2, "MisconductType" },
                    { 72, "di_tre", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Đi trễ", 0, 3, "MisconductType" },
                    { 73, "gian_lan_kiem_tra", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Gian lận kiểm tra", 0, 4, "MisconductType" },
                    { 74, "mat_trat_tu", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Mất trật tự", 0, 5, "MisconductType" },
                    { 75, "khac", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Khác", 0, 6, "MisconductType" },
                    { 76, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "9-10", true, null, "Vững vàng, kiên định", 0, 1, "PoliticalAttitude" },
                    { 77, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-8", true, null, "Tốt", 0, 2, "PoliticalAttitude" },
                    { 78, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "5-7", true, null, "Có khi còn hạn chế", 0, 3, "PoliticalAttitude" },
                    { 79, "level4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-4", true, null, "Một số còn hạn chế, bị nhắc nhở trước tập thể", 0, 4, "PoliticalAttitude" },
                    { 80, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-10", true, null, "Học tập tốt, nghiêm túc", 0, 1, "StudyMotivation" },
                    { 81, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "5-7", true, null, "Chưa cao, còn dao động", 0, 2, "StudyMotivation" },
                    { 82, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-4", true, null, "Hạn chế, chưa nghiêm túc, thiếu cố gắng", 0, 3, "StudyMotivation" },
                    { 83, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-10", true, null, "Tích cực, gương mẫu, đoàn kết tốt", 0, 1, "EthicsLifestyle" },
                    { 84, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "7-7", true, null, "Ý thức kém, đoàn kết còn hạn chế", 0, 2, "EthicsLifestyle" },
                    { 85, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "5-6", true, null, "Phẩm chất đạo đức kém, đoàn kết hạn chế, tác phong chậm", 0, 3, "EthicsLifestyle" },
                    { 86, "level4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-4", true, null, "Thiếu chủ động, thiếu tinh thần xây dựng đơn vị", 0, 4, "EthicsLifestyle" },
                    { 87, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-10", true, null, "Chấp hành nghiêm PL, điều lệnh, điều lệ quân đội", 0, 1, "DisciplineAwareness" },
                    { 88, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "5-7", true, null, "Chưa có ý thức trong các nhiệm vụ tập thể, trốn tránh nhiệm vụ, có tiến bộ sau khi nhắc nhở", 0, 2, "DisciplineAwareness" },
                    { 89, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-4", true, null, "Vi phạm kỷ luật, chuyển biến chậm", 0, 3, "DisciplineAwareness" },
                    { 90, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-10", true, null, "Tốt", 0, 1, "AcademicResult" },
                    { 91, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "5-7", true, null, "Chưa tốt", 0, 2, "AcademicResult" },
                    { 92, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-4", true, null, "Yếu", 0, 3, "AcademicResult" },
                    { 93, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "9-10", true, null, "Có", 0, 1, "ResearchActivity" },
                    { 94, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0-8", true, null, "Không", 0, 2, "ResearchActivity" },
                    { 95, "thuc_hanh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Thực hành", 0, 1, "GraduationExamType" },
                    { 96, "ly_thuyet", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Lý thuyết chuyên môn", 0, 2, "GraduationExamType" },
                    { 97, "chinh_tri", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Chính trị", 0, 3, "GraduationExamType" },
                    { 98, "quan_su", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thi Quân sự chung", 0, 4, "GraduationExamType" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FullName", "IsActive", "LastLoginDate", "ModifiedDate", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@school.edu.vn", "Quản Trị Viên", true, null, null, "$2a$11$eImiTXuWVxfM37uY4JANjOIVEiOrgsTJwzETTD4YOIqFBYWxvRfLy", "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolYearId",
                table: "Classes",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SemesterId",
                table: "Grades",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TraineeId",
                table: "Grades",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationExamScores_TraineeId",
                table: "GraduationExamScores",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationScores_TraineeId",
                table: "GraduationScores",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Misconducts_TraineeId",
                table: "Misconducts",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticePoints_TraineeId",
                table: "PracticePoints",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassId_SubjectId_Room_Period_Date",
                table: "Schedules",
                columns: new[] { "ClassId", "SubjectId", "Room", "Period", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_SchoolYearId",
                table: "Semesters",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAverages_SubjectId",
                table: "SubjectAverages",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAverages_TraineeId",
                table: "SubjectAverages",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Code",
                table: "Subjects",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TraineeAverageScores_SemesterId",
                table: "TraineeAverageScores",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeAverageScores_TraineeId",
                table: "TraineeAverageScores",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ClassId",
                table: "Trainees",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Email",
                table: "Users",
                columns: new[] { "Username", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCritiques_TraineeId",
                table: "WeeklyCritiques",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "GraduationExamScores");

            migrationBuilder.DropTable(
                name: "GraduationScores");

            migrationBuilder.DropTable(
                name: "Misconducts");

            migrationBuilder.DropTable(
                name: "PracticePoints");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RollCalls");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SubjectAverages");

            migrationBuilder.DropTable(
                name: "TraineeAverageScores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeeklyCritiques");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "SchoolYears");
        }
    }
}

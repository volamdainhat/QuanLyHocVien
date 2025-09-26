using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimetableId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

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
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaxStudents = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageGalleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    ThumbPath = table.Column<string>(type: "TEXT", nullable: true),
                    ContentType = table.Column<string>(type: "TEXT", nullable: true),
                    Size = table.Column<long>(type: "INTEGER", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    MisconductCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalAbsences = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageScore = table.Column<float>(type: "REAL", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    DayOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    IdentityCardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Ranking = table.Column<string>(type: "TEXT", nullable: true),
                    Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    StrongPoints = table.Column<string>(type: "TEXT", nullable: true),
                    EnlistmentNotificationPlace = table.Column<string>(type: "TEXT", nullable: true),
                    PlaceofOrigin = table.Column<string>(type: "TEXT", nullable: true),
                    EducationLevel = table.Column<string>(type: "TEXT", nullable: true),
                    HealthStatus = table.Column<string>(type: "TEXT", nullable: true),
                    FatherFullName = table.Column<string>(type: "TEXT", nullable: true),
                    FatherPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MotherFullName = table.Column<string>(type: "TEXT", nullable: true),
                    MotherPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ContactAddress = table.Column<string>(type: "TEXT", nullable: true),
                    MilitaryCode = table.Column<string>(type: "TEXT", nullable: true),
                    EnlistmentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EnlistmentProvince = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    MeritScore = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassName = table.Column<string>(type: "TEXT", nullable: true),
                    AverageScore = table.Column<decimal>(type: "TEXT", nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Room = table.Column<string>(type: "TEXT", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectName = table.Column<string>(type: "TEXT", nullable: false),
                    ExamTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Trainees_TraineeId",
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
                    Description = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "SubjectAverageScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Semester = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    SchoolYear = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CalculatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsLocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAverageScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectAverageScores_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAverageScores_Trainees_TraineeId",
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
                    StudyMotivation = table.Column<string>(type: "TEXT", nullable: true),
                    EthicsLifestyle = table.Column<string>(type: "TEXT", nullable: true),
                    DisciplineAwareness = table.Column<string>(type: "TEXT", nullable: true),
                    AcademicResult = table.Column<string>(type: "TEXT", nullable: true),
                    ResearchActivity = table.Column<string>(type: "TEXT", nullable: true),
                    FinalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    WeekDate = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                columns: new[] { "Id", "Code", "Description", "IsActive", "Name", "SortOrder", "Type" },
                values: new object[,]
                {
                    { 1, "hoc_vien", null, true, "Học viên", 1, "Role" },
                    { 2, "tieu_truong", null, true, "Tiểu đội trưởng", 2, "Role" },
                    { 3, "lop_truong", null, true, "Lớp trưởng", 3, "Role" },
                    { 4, "hoc_tap", null, true, "Lớp phó học tập", 4, "Role" },
                    { 5, "hau_can", null, true, "Lớp phó hậu cần", 5, "Role" },
                    { 6, "kt_15p", null, true, "Kiểm tra 15 phút", 1, "ExamType" },
                    { 7, "kt_1t", null, true, "Kiểm tra 1 tiết", 2, "ExamType" },
                    { 8, "thi", null, true, "Thi cuối môn", 3, "ExamType" },
                    { 9, "B2", null, true, "Binh nhì", 1, "MilitaryRank" },
                    { 10, "B1", null, true, "Binh nhất", 2, "MilitaryRank" },
                    { 11, "H1", null, true, "Hạ sĩ", 3, "MilitaryRank" },
                    { 12, "H2", null, true, "Trung sĩ", 4, "MilitaryRank" },
                    { 13, "H3", null, true, "Thượng sĩ", 5, "MilitaryRank" },
                    { 14, "1/", null, true, "Thiếu úy", 6, "MilitaryRank" },
                    { 15, "2/", null, true, "Trung úy", 7, "MilitaryRank" },
                    { 16, "3/", null, true, "Thượng úy", 8, "MilitaryRank" },
                    { 17, "4/", null, true, "Đại úy", 9, "MilitaryRank" },
                    { 18, "1//", null, true, "Thiếu tá", 10, "MilitaryRank" },
                    { 19, "2//", null, true, "Trung tá", 11, "MilitaryRank" },
                    { 20, "3//", null, true, "Thượng tá", 12, "MilitaryRank" },
                    { 21, "4//", null, true, "Đại tá", 13, "MilitaryRank" },
                    { 22, "ha_noi_01", null, true, "Thành phố Hà Nội", 1, "Provinces" },
                    { 23, "cao_bang_04", null, true, "Tỉnh Cao Bằng", 2, "Provinces" },
                    { 24, "tuyen_quang_08", null, true, "Tỉnh Tuyên Quang", 3, "Provinces" },
                    { 25, "dien_bien_11", null, true, "Tỉnh Điện Biên", 4, "Provinces" },
                    { 26, "lai_chau_12", null, true, "Tỉnh Lai Châu", 5, "Provinces" },
                    { 27, "son_la_14", null, true, "Tỉnh Sơn La", 6, "Provinces" },
                    { 28, "lao_cai_15", null, true, "Tỉnh Lào Cai", 7, "Provinces" },
                    { 29, "thai_nguyen_19", null, true, "Tỉnh Thái Nguyên", 8, "Provinces" },
                    { 30, "lang_son_20", null, true, "Tỉnh Lạng Sơn", 9, "Provinces" },
                    { 31, "quang_ninh_22", null, true, "Tỉnh Quảng Ninh", 10, "Provinces" },
                    { 32, "bac_ninh_24", null, true, "Tỉnh Bắc Ninh", 11, "Provinces" },
                    { 33, "phu_tho_25", null, true, "Tỉnh Phú Thọ", 12, "Provinces" },
                    { 34, "hai_phong_31", null, true, "Thành phố Hải Phòng", 13, "Provinces" },
                    { 35, "hung_yen_33", null, true, "Tỉnh Hưng Yên", 14, "Provinces" },
                    { 36, "ninh_binh_37", null, true, "Tỉnh Ninh Bình", 15, "Provinces" },
                    { 37, "thanh_hoa_38", null, true, "Tỉnh Thanh Hóa", 16, "Provinces" },
                    { 38, "nghe_an_40", null, true, "Tỉnh Nghệ An", 17, "Provinces" },
                    { 39, "ha_tinh_42", null, true, "Tỉnh Hà Tĩnh", 18, "Provinces" },
                    { 40, "quang_tri_44", null, true, "Tỉnh Quảng Trị", 19, "Provinces" },
                    { 41, "hue_46", null, true, "Thành phố Huế", 20, "Provinces" },
                    { 42, "da_nang_48", null, true, "Thành phố Đà Nẵng", 21, "Provinces" },
                    { 43, "quang_ngai_51", null, true, "Tỉnh Quảng Ngãi", 22, "Provinces" },
                    { 44, "gia_lai_52", null, true, "Tỉnh Gia Lai", 23, "Provinces" },
                    { 45, "khanh_hoa_56", null, true, "Tỉnh Khánh Hòa", 24, "Provinces" },
                    { 46, "dak_lak_66", null, true, "Tỉnh Đắk Lắk", 25, "Provinces" },
                    { 47, "lam_dong_68", null, true, "Tỉnh Lâm Đồng", 26, "Provinces" },
                    { 48, "dong_nai_75", null, true, "Tỉnh Đồng Nai", 27, "Provinces" },
                    { 49, "ho_chi_minh_79", null, true, "Thành phố Hồ Chí Minh", 28, "Provinces" },
                    { 51, "tay_ninh_80", null, true, "Tỉnh Tây Ninh", 29, "Provinces" },
                    { 52, "dong_thap_82", null, true, "Tỉnh Đồng Tháp", 30, "Provinces" },
                    { 53, "vinh_long_86", null, true, "Tỉnh Vĩnh Long", 31, "Provinces" },
                    { 54, "an_giang_91", null, true, "Tỉnh An Giang", 32, "Provinces" },
                    { 55, "can_tho_92", null, true, "Thành phố Cần Thơ", 33, "Provinces" },
                    { 56, "ca_mau_96", null, true, "Tỉnh Cà Mau", 34, "Provinces" },
                    { 59, "thcs", null, true, "9/12", 3, "EducationLevel" },
                    { 60, "thpt", null, true, "12/12", 4, "EducationLevel" },
                    { 61, "trung_cap", null, true, "Trung cấp", 5, "EducationLevel" },
                    { 62, "cao_dang", null, true, "Cao đẳng", 6, "EducationLevel" },
                    { 63, "dai_hoc", null, true, "Đại học", 7, "EducationLevel" },
                    { 64, "thac_si", null, true, "Thạc sĩ", 8, "EducationLevel" },
                    { 65, "tien_si", null, true, "Tiến sĩ", 9, "EducationLevel" },
                    { 66, "pho_giao_su", null, true, "Phó Giáo sư", 10, "EducationLevel" },
                    { 67, "giao_su", null, true, "Giáo sư", 11, "EducationLevel" },
                    { 68, "sang", null, true, "Buổi sáng", 1, "SchedulePeriod" },
                    { 69, "chieu", null, true, "Buổi chiều", 2, "SchedulePeriod" },
                    { 100, "nam", null, true, "Nam", 1, "Gender" },
                    { 101, "nu", null, true, "Nữ", 2, "Gender" },
                    { 102, "khac", null, true, "Khác", 3, "Gender" },
                    { 110, "tot", null, true, "Tốt", 1, "HealthStatus" },
                    { 111, "kha", null, true, "Khá", 2, "HealthStatus" },
                    { 112, "trung_binh", null, true, "Trung bình", 3, "HealthStatus" },
                    { 113, "yeu", null, true, "Yếu", 4, "HealthStatus" },
                    { 130, "kinh", null, true, "Kinh", 1, "Ethnicity" },
                    { 131, "tay", null, true, "Tày", 2, "Ethnicity" },
                    { 132, "thai", null, true, "Thái", 3, "Ethnicity" },
                    { 133, "muong", null, true, "Mường", 4, "Ethnicity" },
                    { 134, "khmer", null, true, "Khmer", 5, "Ethnicity" },
                    { 135, "hoa", null, true, "Hoa", 6, "Ethnicity" },
                    { 136, "nung", null, true, "Nùng", 7, "Ethnicity" },
                    { 137, "hmong", null, true, "HMông", 8, "Ethnicity" },
                    { 138, "dao", null, true, "Dao", 9, "Ethnicity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Type_Code",
                table: "Categories",
                columns: new[] { "Type", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TraineeId",
                table: "Grades",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Misconducts_TraineeId",
                table: "Misconducts",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ClassId",
                table: "Reports",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassId",
                table: "Schedules",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAverageScores_SubjectId",
                table: "SubjectAverageScores",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAverageScores_TraineeId_SubjectId_Semester_SchoolYear",
                table: "SubjectAverageScores",
                columns: new[] { "TraineeId", "SubjectId", "Semester", "SchoolYear" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ClassId",
                table: "Trainees",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCritiques_TraineeId",
                table: "WeeklyCritiques",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "ImageGalleries");

            migrationBuilder.DropTable(
                name: "Misconducts");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SubjectAverageScores");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "WeeklyCritiques");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}

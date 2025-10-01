using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWeeklyCritique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 76, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Vững vàng, kiên định", 0, 1, "PoliticalAttitude" },
                    { 77, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tốt", 0, 2, "PoliticalAttitude" },
                    { 78, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Có khi còn hạn chế", 0, 3, "PoliticalAttitude" },
                    { 79, "level4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Một số còn hạn chế, bị nhắc nhở trước tập thể", 0, 4, "PoliticalAttitude" },
                    { 80, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Học tập tốt, nghiêm túc", 0, 1, "StudyMotivation" },
                    { 81, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Chưa cao, còn dao động", 0, 2, "StudyMotivation" },
                    { 82, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Hạn chế, chưa nghiêm túc, thiếu cố gắng", 0, 3, "StudyMotivation" },
                    { 83, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tích cực, gương mẫu, đoàn kết tốt", 0, 1, "EthicsLifestyle" },
                    { 84, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Ý thức kém, đoàn kết còn hạn chế", 0, 2, "EthicsLifestyle" },
                    { 85, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Phẩm chất đạo đức kém, đoàn kết hạn chế, tác phong chậm", 0, 3, "EthicsLifestyle" },
                    { 86, "level4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Thiếu chủ động, thiếu tinh thần xây dựng đơn vị", 0, 4, "EthicsLifestyle" },
                    { 87, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Chấp hành nghiêm PL, điều lệnh, điều lệ quân đội", 0, 1, "DisciplineAwareness" },
                    { 88, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Chưa có ý thức trong các nhiệm vụ tập thể, trốn tránh nhiệm vụ, có tiến bộ sau khi nhắc nhở", 0, 2, "DisciplineAwareness" },
                    { 89, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Vi phạm kỷ luật, chuyển biến chậm", 0, 3, "DisciplineAwareness" },
                    { 90, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Tốt", 0, 1, "AcademicResult" },
                    { 91, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Chưa tốt", 0, 2, "AcademicResult" },
                    { 92, "level3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Yếu", 0, 3, "AcademicResult" },
                    { 93, "level1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Có", 0, 1, "ResearchActivity" },
                    { 94, "level2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, true, null, "Không", 0, 2, "ResearchActivity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCritiques_TraineeId",
                table: "WeeklyCritiques",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyCritiques");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94);
        }
    }
}

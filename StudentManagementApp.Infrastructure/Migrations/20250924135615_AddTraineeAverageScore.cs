using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTraineeAverageScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraineeAverageScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SemesterId = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    GradeType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_TraineeAverageScores_SemesterId",
                table: "TraineeAverageScores",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeAverageScores_TraineeId",
                table: "TraineeAverageScores",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineeAverageScores");
        }
    }
}

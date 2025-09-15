using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddWeeklyCritiques_Cols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                table: "WeeklyCritiques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "WeekDate",
                table: "WeeklyCritiques",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyCritiques_TraineeId",
                table: "WeeklyCritiques",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyCritiques_Trainees_TraineeId",
                table: "WeeklyCritiques",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyCritiques_Trainees_TraineeId",
                table: "WeeklyCritiques");

            migrationBuilder.DropIndex(
                name: "IX_WeeklyCritiques_TraineeId",
                table: "WeeklyCritiques");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "WeeklyCritiques");

            migrationBuilder.DropColumn(
                name: "WeekDate",
                table: "WeeklyCritiques");
        }
    }
}

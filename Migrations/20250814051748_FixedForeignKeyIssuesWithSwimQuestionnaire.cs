using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixedForeignKeyIssuesWithSwimQuestionnaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwimQuestionnaire_Swims_SwimId1",
                table: "SwimQuestionnaire");

            migrationBuilder.DropIndex(
                name: "IX_SwimQuestionnaire_SwimId1",
                table: "SwimQuestionnaire");

            migrationBuilder.DropColumn(
                name: "SwimId",
                table: "SwimQuestionnaire");

            migrationBuilder.DropColumn(
                name: "SwimId1",
                table: "SwimQuestionnaire");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SwimId",
                table: "SwimQuestionnaire",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SwimId1",
                table: "SwimQuestionnaire",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SwimQuestionnaire_SwimId1",
                table: "SwimQuestionnaire",
                column: "SwimId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SwimQuestionnaire_Swims_SwimId1",
                table: "SwimQuestionnaire",
                column: "SwimId1",
                principalTable: "Swims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

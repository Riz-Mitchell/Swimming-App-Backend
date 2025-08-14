using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupportForSwimQuestionnaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerceivedExertion",
                table: "Swims");

            migrationBuilder.AddColumn<Guid>(
                name: "SwimQuestionnaireId",
                table: "Swims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SwimQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SelfTalk = table.Column<int>(type: "integer", nullable: false),
                    Nerves = table.Column<int>(type: "integer", nullable: false),
                    EnergyLevel = table.Column<int>(type: "integer", nullable: false),
                    Breathing = table.Column<int>(type: "integer", nullable: false),
                    CatchFeel = table.Column<int>(type: "integer", nullable: false),
                    StrokeLength = table.Column<int>(type: "integer", nullable: false),
                    KickTechnique = table.Column<int>(type: "integer", nullable: false),
                    KickThroughout = table.Column<int>(type: "integer", nullable: false),
                    HeadPosition = table.Column<int>(type: "integer", nullable: false),
                    Turn = table.Column<int>(type: "integer", nullable: false),
                    SwimId = table.Column<Guid>(type: "uuid", nullable: false),
                    SwimId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimQuestionnaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwimQuestionnaire_Swims_SwimId1",
                        column: x => x.SwimId1,
                        principalTable: "Swims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Swims_SwimQuestionnaireId",
                table: "Swims",
                column: "SwimQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimQuestionnaire_SwimId1",
                table: "SwimQuestionnaire",
                column: "SwimId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_SwimQuestionnaire_SwimQuestionnaireId",
                table: "Swims",
                column: "SwimQuestionnaireId",
                principalTable: "SwimQuestionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_SwimQuestionnaire_SwimQuestionnaireId",
                table: "Swims");

            migrationBuilder.DropTable(
                name: "SwimQuestionnaire");

            migrationBuilder.DropIndex(
                name: "IX_Swims_SwimQuestionnaireId",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "SwimQuestionnaireId",
                table: "Swims");

            migrationBuilder.AddColumn<int>(
                name: "PerceivedExertion",
                table: "Swims",
                type: "integer",
                nullable: true);
        }
    }
}

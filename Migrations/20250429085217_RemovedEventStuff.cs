using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEventStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Events_EventId",
                table: "Swims");

            migrationBuilder.DropTable(
                name: "GoalSwims");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Swims_EventId",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Swims");

            migrationBuilder.AddColumn<int>(
                name: "Event",
                table: "TimeSheets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Event",
                table: "Swims",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "Swims");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "TimeSheets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Swims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSheetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    EventEnum = table.Column<int>(type: "integer", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_TimeSheets_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalTable: "TimeSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalSwims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AthleteDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrokeCount = table.Column<int>(type: "integer", nullable: true),
                    StrokeRate = table.Column<int>(type: "integer", nullable: true),
                    Time = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSwims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalSwims_AthleteDatas_AthleteDataOwnerId",
                        column: x => x.AthleteDataOwnerId,
                        principalTable: "AthleteDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalSwims_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Swims_EventId",
                table: "Swims",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimeSheetId",
                table: "Events",
                column: "TimeSheetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoalSwims_AthleteDataOwnerId",
                table: "GoalSwims",
                column: "AthleteDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSwims_EventId",
                table: "GoalSwims",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Events_EventId",
                table: "Swims",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

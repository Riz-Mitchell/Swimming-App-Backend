using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_TimeTables_TimeTableId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Squads_SquadId",
                table: "TimeTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeTables",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "GoalTime",
                table: "AthleteDatas");

            migrationBuilder.DropColumn(
                name: "MainDistance",
                table: "AthleteDatas");

            migrationBuilder.DropColumn(
                name: "MainStroke",
                table: "AthleteDatas");

            migrationBuilder.RenameTable(
                name: "TimeTables",
                newName: "Timetables");

            migrationBuilder.RenameIndex(
                name: "IX_TimeTables_SquadId",
                table: "Timetables",
                newName: "IX_Timetables_SquadId");

            migrationBuilder.RenameColumn(
                name: "GoalTime",
                table: "Swims",
                newName: "GoalSwim");

            migrationBuilder.RenameColumn(
                name: "TimeTableId",
                table: "Sessions",
                newName: "TimetableId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_TimeTableId",
                table: "Sessions",
                newName: "IX_Sessions_TimetableId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Timetables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Timetables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Timetables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Timetables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOffGoalStrokeRate",
                table: "Swims",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOffGoalTime",
                table: "Swims",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOffPBStrokeRate",
                table: "Swims",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOffPBTime",
                table: "Swims",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrokeCount",
                table: "Swims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrokeCount",
                table: "GoalSwims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventEnum",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timetables",
                table: "Timetables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Timetables_TimetableId",
                table: "Sessions",
                column: "TimetableId",
                principalTable: "Timetables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Squads_SquadId",
                table: "Timetables",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Timetables_TimetableId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Squads_SquadId",
                table: "Timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timetables",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "PercentageOffGoalStrokeRate",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "PercentageOffGoalTime",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "PercentageOffPBStrokeRate",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "PercentageOffPBTime",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "StrokeCount",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "StrokeCount",
                table: "GoalSwims");

            migrationBuilder.DropColumn(
                name: "EventEnum",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Timetables",
                newName: "TimeTables");

            migrationBuilder.RenameIndex(
                name: "IX_Timetables_SquadId",
                table: "TimeTables",
                newName: "IX_TimeTables_SquadId");

            migrationBuilder.RenameColumn(
                name: "GoalSwim",
                table: "Swims",
                newName: "GoalTime");

            migrationBuilder.RenameColumn(
                name: "TimetableId",
                table: "Sessions",
                newName: "TimeTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_TimetableId",
                table: "Sessions",
                newName: "IX_Sessions_TimeTableId");

            migrationBuilder.AddColumn<string>(
                name: "GoalTime",
                table: "AthleteDatas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainDistance",
                table: "AthleteDatas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainStroke",
                table: "AthleteDatas",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeTables",
                table: "TimeTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_TimeTables_TimeTableId",
                table: "Sessions",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Squads_SquadId",
                table: "TimeTables",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

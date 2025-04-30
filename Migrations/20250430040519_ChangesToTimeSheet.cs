using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToTimeSheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheetsItems");

            migrationBuilder.AddColumn<string>(
                name: "SplitDataForTimes",
                table: "TimeSheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SplitDataForTimes",
                table: "TimeSheets");

            migrationBuilder.CreateTable(
                name: "TimeSheetsItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSheetId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentInterval = table.Column<double>(type: "double precision", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetsItems_TimeSheets_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalTable: "TimeSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetsItems_TimeSheetId",
                table: "TimeSheetsItems",
                column: "TimeSheetId");
        }
    }
}

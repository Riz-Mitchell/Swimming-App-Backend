using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSplitDataForTimesComparer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Dive",
                table: "Swims");

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
                name: "PotentialRaceTime",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Stroke",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "StrokeCount",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "StrokeRate",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Swims");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Users",
                type: "double precision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false),
                    IntervalTime = table.Column<double>(type: "double precision", nullable: false),
                    IntervalDistance = table.Column<int>(type: "integer", nullable: false),
                    IntervalStrokeRate = table.Column<int>(type: "integer", nullable: true),
                    IntervalStrokeCount = table.Column<int>(type: "integer", nullable: true),
                    PerOffPBIntervalTime = table.Column<double>(type: "double precision", nullable: true),
                    PerOffPBStrokeRate = table.Column<double>(type: "double precision", nullable: true),
                    PerOffGoalTime = table.Column<double>(type: "double precision", nullable: true),
                    PerOffGoalStrokeRate = table.Column<double>(type: "double precision", nullable: true),
                    Dive = table.Column<bool>(type: "boolean", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SwimId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Splits_Swims_SwimId",
                        column: x => x.SwimId,
                        principalTable: "Swims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Splits_SwimId",
                table: "Splits",
                column: "SwimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Swims",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Dive",
                table: "Swims",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<double>(
                name: "PotentialRaceTime",
                table: "Swims",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stroke",
                table: "Swims",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrokeCount",
                table: "Swims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrokeRate",
                table: "Swims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Time",
                table: "Swims",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "Difficulty", "Name", "TargetValue", "UserType" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Log 10 freestyle swims.", 2, "Freestyle beginner", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Log 50 freestyle swims.", 4, "Freestyle connoisseur", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Log 100 freestyle swims.", 6, "Freestyle king", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Log 10 breaststroke swims.", 2, "Breaststroke beginner", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Log 50 breaststroke swims.", 4, "Breaststroke connoisseur", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "Log 100 breaststroke swims.", 6, "Breaststroke king", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "Log 10 backstroke swims.", 2, "Backstroke beginner", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "Log 50 backstroke swims.", 4, "Backstroke connoisseur", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "Log 100 backstroke swims.", 6, "Backstroke king", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "Log 10 butterfly swims.", 2, "Butterfly beginner", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "Log 50 butterfly swims.", 4, "Butterfly connoisseur", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "Log 100 butterfly swims.", 6, "Butterfly king", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Log 10 IM swims.", 2, "IM beginner", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "Log 50 IM swims.", 4, "IM connoisseur", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "Log 100 IM swims.", 6, "IM king", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "Log swims in all four strokes.", 3, "Stroke Master", 4, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "Beat your personal best time for any event.", 2, "PB Chaser", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "Achieve a goal swim time.", 3, "Goal Getter", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "Log 10 swims before 7 AM.", 2, "Morning Grind", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "Log 10 swims before 6 AM.", 5, "Alright maybe you should sleep in", 10, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "Log 50 swims before 5:30AM.", 8, "Dying early", 50, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "Make 5 friends.", 2, "Social Swimmer", 5, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "Make 20 friends.", 4, "Great guy, amazing guy", 5, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "Log a swim with a perceived exertion of 10.", 1, "Exertion King", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "Swim a 200m event with a perceived exertion of 10.", 3, "Try hard", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "Log 5 swims with a perceived exertion of 8 or more in a span of 30 minutes.", 7, "I need a break. AHHHHHHH I NEED A BREAK!!!!", 1, 0 }
                });
        }
    }
}

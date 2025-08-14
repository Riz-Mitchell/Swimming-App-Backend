using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:breathing_options_enum", "unselected,normal,fast,deep,erratic")
                .Annotation("Npgsql:Enum:catch_feel_options_enum", "unselected,strong,weak,slipping,wide,narrow")
                .Annotation("Npgsql:Enum:energy_level_options_enum", "unselected,low,moderate,high,very_high")
                .Annotation("Npgsql:Enum:head_position_options_enum", "unselected,looking_forward,looking_down,head_high,head_low,head_neutral")
                .Annotation("Npgsql:Enum:kick_technique_options_enum", "unselected,small,big")
                .Annotation("Npgsql:Enum:kick_throughout_options_enum", "unselected,consistent,speeding_up,slowing_down")
                .Annotation("Npgsql:Enum:nerves_options_enum", "unselected,relaxed,jittery,tense,heavy,light,nauseous")
                .Annotation("Npgsql:Enum:self_talk_options_enum", "unselected,none,motivational_positive,motivational_negative,instructive_positive,instructive_negative,outcome_positive,outcome_negative")
                .Annotation("Npgsql:Enum:stroke_length_options_enum", "unselected,longer,shorter")
                .Annotation("Npgsql:Enum:turn_options_enum", "unselected,good,too_far,too_close,felt_slow,felt_fast");

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TargetValue = table.Column<int>(type: "integer", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AthleteDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoachDatas",
                columns: table => new
                {
                    CoachDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachDatas", x => x.CoachDataId);
                });

            migrationBuilder.CreateTable(
                name: "SwimQuestionnaire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SelfTalk = table.Column<int>(type: "integer", nullable: false),
                    Nerves = table.Column<int[]>(type: "integer[]", nullable: false),
                    EnergyLevel = table.Column<int>(type: "integer", nullable: false),
                    Breathing = table.Column<int>(type: "integer", nullable: false),
                    CatchFeel = table.Column<int[]>(type: "integer[]", nullable: false),
                    StrokeLength = table.Column<int>(type: "integer", nullable: false),
                    KickTechnique = table.Column<int>(type: "integer", nullable: false),
                    KickThroughout = table.Column<int>(type: "integer", nullable: false),
                    HeadPosition = table.Column<int[]>(type: "integer[]", nullable: false),
                    Turn = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimQuestionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Event = table.Column<int>(type: "integer", nullable: false),
                    SplitDataForTimes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AthleteDataId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoachDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AthleteDatas_AthleteDataId",
                        column: x => x.AthleteDataId,
                        principalTable: "AthleteDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_CoachDatas_CoachDataId",
                        column: x => x.CoachDataId,
                        principalTable: "CoachDatas",
                        principalColumn: "CoachDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Swims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Event = table.Column<int>(type: "integer", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GoalSwim = table.Column<bool>(type: "boolean", nullable: false),
                    PoolType = table.Column<int>(type: "integer", nullable: false),
                    IsExternal = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExternalSource = table.Column<int>(type: "integer", nullable: true),
                    SwimQuestionnaireId = table.Column<Guid>(type: "uuid", nullable: false),
                    AthleteDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swims_AthleteDatas_AthleteDataOwnerId",
                        column: x => x.AthleteDataOwnerId,
                        principalTable: "AthleteDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Swims_SwimQuestionnaire_SwimQuestionnaireId",
                        column: x => x.SwimQuestionnaireId,
                        principalTable: "SwimQuestionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddresseeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_AddresseeId",
                        column: x => x.AddresseeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Progress = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    EarnedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AchievementId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OriginalTransactionId = table.Column<string>(type: "text", nullable: true),
                    PurchaseToken = table.Column<string>(type: "text", nullable: true),
                    Receipt = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "Difficulty", "Name", "TargetValue", "UserType" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Swim a total of 10,000 meters.", 4, "Marathon Swimmer", 10000, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Log your first swim session.", 1, "First Swim", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Log 20 swims.", 2, "Getting it done", 20, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Log 100 swims.", 3, "Busy cooking", 100, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Log 200 swims.", 4, "Proper chef", 200, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "You made your first 1000, congratulations, we gotta do at least 20 bro. Log 1000 swims.", 8, "Gotta do at least 20 bro", 1000, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "How did you do that? Log 2000 swims", 10, "Ashton Hall", 2000, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Account over a year old.", 6, "Unc status", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Account over 2 years old.", 8, "Fossil", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "One of the first 20 users to join.", 10, "Founding member", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "One of the first 100 users to join.", 8, "Early adopter", 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "One of the first 1000 users to join.", 6, "First 1000", 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_Name",
                table: "Achievements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_AddresseeId",
                table: "Friendships",
                column: "AddresseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_IsConfirmed",
                table: "Friendships",
                column: "IsConfirmed");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_RequesterId",
                table: "Friendships",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_RequesterId_AddresseeId",
                table: "Friendships",
                columns: new[] { "RequesterId", "AddresseeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Splits_SwimId",
                table: "Splits",
                column: "SwimId");

            migrationBuilder.CreateIndex(
                name: "IX_Swims_AthleteDataOwnerId",
                table: "Swims",
                column: "AthleteDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Swims_SwimQuestionnaireId",
                table: "Swims",
                column: "SwimQuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UserId_AchievementId",
                table: "UserAchievements",
                columns: new[] { "UserId", "AchievementId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AthleteDataId",
                table: "Users",
                column: "AthleteDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CoachDataId",
                table: "Users",
                column: "CoachDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_UserId",
                table: "UserSubscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "Swims");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SwimQuestionnaire");

            migrationBuilder.DropTable(
                name: "AthleteDatas");

            migrationBuilder.DropTable(
                name: "CoachDatas");
        }
    }
}

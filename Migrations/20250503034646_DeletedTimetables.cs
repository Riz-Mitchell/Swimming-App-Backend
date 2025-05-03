using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class DeletedTimetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AthleteDatas_AthleteDataId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_CoachDatas_CoachDataId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squads_SquadId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AthleteDataAward");

            migrationBuilder.DropTable(
                name: "SetItems");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Users_SquadId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_AthleteDataId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_CoachDataId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AthleteDataId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "CoachDataId",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Achievements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Achievements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetValue",
                table: "Achievements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Achievements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pgrogress = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "Description", "Difficulty", "Name", "TargetValue", "UserType" },
                values: new object[,]
                {
                    { new Guid("0d582ba2-4797-4448-ae2f-03ee2523522d"), "Log 100 IM swims.", 6, "IM king", 100, 0 },
                    { new Guid("13c37e8b-c29c-4afa-bb5f-48fc438cfcb9"), "Log swims in all four strokes.", 3, "Stroke Master", 4, 0 },
                    { new Guid("1422e4df-2d45-40af-8b31-657d961afe4d"), "Achieve a goal swim time.", 3, "Goal Getter", 1, 0 },
                    { new Guid("26b42ab5-58c4-4a2a-ab7d-7df8a870d251"), "Log 50 butterfly swims.", 4, "Butterfly connoisseur", 50, 0 },
                    { new Guid("2ef92173-794e-40db-8ef6-812f8cae1cbf"), "Log 5 swims with a perceived exertion of 8 or more in a span of 30 minutes.", 7, "I need a break. AHHHHHHH I NEED A BREAK!!!!", 1, 0 },
                    { new Guid("3989af43-e64b-4aa1-a9d2-36c295822f6f"), "Account over 2 years old.", 8, "Fossil", 1, 0 },
                    { new Guid("3e35bdb0-eed2-4297-a059-5cdedd926cd2"), "Log a swim with a perceived exertion of 10.", 1, "Exertion King", 1, 0 },
                    { new Guid("3eece4f4-3e54-4df5-a050-9c1fbf9a060f"), "Log 100 breaststroke swims.", 6, "Breaststroke king", 100, 0 },
                    { new Guid("4053db8b-7feb-4589-81a6-f38ce1e50e37"), "Log 50 freestyle swims.", 4, "Freestyle connoisseur", 50, 0 },
                    { new Guid("40c634e3-6213-4973-a2aa-a93f7a74d768"), "Log 10 butterfly swims.", 2, "Butterfly beginner", 10, 0 },
                    { new Guid("4829209a-b3d6-4820-954e-499903081052"), "Account over a year old.", 6, "Unc status", 1, 0 },
                    { new Guid("4bc81770-e3e9-4c28-a89c-95787281084a"), "Swim a 200m event with a perceived exertion of 10.", 3, "Try hard", 1, 0 },
                    { new Guid("64c0bb01-e05c-4baa-937a-7a9f05116637"), "Log 50 IM swims.", 4, "IM connoisseur", 50, 0 },
                    { new Guid("6b2a1855-20b5-412c-a27c-f90021747f13"), "How did you do that? Log 2000 swims", 10, "Ashton Hall", 2000, 0 },
                    { new Guid("72a9f4b3-908c-40d8-82d2-abb963ce55dd"), "Log 200 swims.", 4, "Proper chef", 200, 0 },
                    { new Guid("72d8c6ef-0fd7-4d23-a885-41a198423134"), "Log 100 freestyle swims.", 6, "Freestyle king", 100, 0 },
                    { new Guid("74ca7f30-c3d0-442a-9368-b1877fb2ac01"), "Swim a total of 10,000 meters.", 4, "Marathon Swimmer", 10000, 0 },
                    { new Guid("7916c7b0-260f-4624-8f13-c96de89e5bc7"), "Log 100 backstroke swims.", 6, "Backstroke king", 100, 0 },
                    { new Guid("847799a3-97af-4f8f-96ea-533fdee5ecda"), "You made your first 1000, congratulations, we gotta do at least 20 bro. Log 1000 swims.", 8, "Gotta do at least 20 bro", 1000, 0 },
                    { new Guid("8b62a645-d234-48c2-9f27-6fd61927191c"), "Beat your personal best time for any event.", 2, "PB Chaser", 1, 0 },
                    { new Guid("8c55c63c-8097-4e9d-8c9d-96de0e721dae"), "Make 5 friends.", 2, "Social Swimmer", 5, 0 },
                    { new Guid("8f9814a6-a8bd-4019-ac37-20e0b70a1d7b"), "One of the first 100 users to join.", 8, "Early adopter", 1, 0 },
                    { new Guid("96918ede-f84c-41b6-bf2e-49ad627ef37f"), "Log 10 backstroke swims.", 2, "Backstroke beginner", 10, 0 },
                    { new Guid("9e76d87d-0879-48a5-aec2-6b2df69e1836"), "Log 50 breaststroke swims.", 4, "Breaststroke connoisseur", 50, 0 },
                    { new Guid("a1bc78d7-3e42-44a0-8eaf-d809c4b7ead9"), "Log 20 swims.", 2, "Getting it done", 20, 0 },
                    { new Guid("a21a7432-c76e-4107-a42b-cce80ef5753a"), "Log 100 butterfly swims.", 6, "Butterfly king", 100, 0 },
                    { new Guid("a647ff5c-d1fe-4dd9-b503-9181b769eb47"), "One of the first 1000 users to join.", 6, "First 1000", 1, 0 },
                    { new Guid("b20148c7-e6d2-4621-9fd6-34309ad44f24"), "Log 100 swims.", 3, "Busy cooking", 100, 0 },
                    { new Guid("bbe8bff1-b756-4dfd-a819-23f24c215408"), "Log 50 backstroke swims.", 4, "Backstroke connoisseur", 50, 0 },
                    { new Guid("c6f885eb-fae8-4c07-b6dd-2d2a5b7015e1"), "Log 10 swims before 7 AM.", 2, "Morning Grind", 10, 0 },
                    { new Guid("c87b313c-f63f-45fc-9bd9-84ab3020531b"), "Log 50 swims before 5:30AM.", 8, "Dying early", 50, 0 },
                    { new Guid("d045cd15-6d0c-4c47-b4d9-20a9e9ab681c"), "Log 10 breaststroke swims.", 2, "Breaststroke beginner", 10, 0 },
                    { new Guid("da47aa8a-413e-48b9-8438-f37ee05bd3bb"), "Log 10 freestyle swims.", 2, "Freestyle beginner", 10, 0 },
                    { new Guid("de14c71c-9f44-4c30-96e4-b2ea81fb0670"), "One of the first 20 users to join.", 10, "Founding member", 1, 0 },
                    { new Guid("e463bd58-27d0-4040-9161-2eff4c0167ab"), "Make 20 friends.", 4, "Great guy, amazing guy", 5, 0 },
                    { new Guid("f3f4bf24-da71-407d-ad16-30596b649c5e"), "Log 10 swims before 6 AM.", 5, "Alright maybe you should sleep in", 10, 0 },
                    { new Guid("f6287bec-d4b1-4112-8fc3-174620a37896"), "Log your first swim session.", 1, "First Swim", 1, 0 },
                    { new Guid("fec928d8-adc1-4e4e-84b0-74064865f0b2"), "Log 10 IM swims.", 2, "IM beginner", 10, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_Name",
                table: "Achievements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UserId_AchievementId",
                table: "UserAchievements",
                columns: new[] { "UserId", "AchievementId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_Name",
                table: "Achievements");

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("0d582ba2-4797-4448-ae2f-03ee2523522d"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("13c37e8b-c29c-4afa-bb5f-48fc438cfcb9"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("1422e4df-2d45-40af-8b31-657d961afe4d"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("26b42ab5-58c4-4a2a-ab7d-7df8a870d251"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("2ef92173-794e-40db-8ef6-812f8cae1cbf"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("3989af43-e64b-4aa1-a9d2-36c295822f6f"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("3e35bdb0-eed2-4297-a059-5cdedd926cd2"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("3eece4f4-3e54-4df5-a050-9c1fbf9a060f"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("4053db8b-7feb-4589-81a6-f38ce1e50e37"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("40c634e3-6213-4973-a2aa-a93f7a74d768"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("4829209a-b3d6-4820-954e-499903081052"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("4bc81770-e3e9-4c28-a89c-95787281084a"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("64c0bb01-e05c-4baa-937a-7a9f05116637"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("6b2a1855-20b5-412c-a27c-f90021747f13"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("72a9f4b3-908c-40d8-82d2-abb963ce55dd"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("72d8c6ef-0fd7-4d23-a885-41a198423134"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("74ca7f30-c3d0-442a-9368-b1877fb2ac01"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("7916c7b0-260f-4624-8f13-c96de89e5bc7"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("847799a3-97af-4f8f-96ea-533fdee5ecda"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("8b62a645-d234-48c2-9f27-6fd61927191c"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("8c55c63c-8097-4e9d-8c9d-96de0e721dae"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("8f9814a6-a8bd-4019-ac37-20e0b70a1d7b"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("96918ede-f84c-41b6-bf2e-49ad627ef37f"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("9e76d87d-0879-48a5-aec2-6b2df69e1836"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("a1bc78d7-3e42-44a0-8eaf-d809c4b7ead9"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("a21a7432-c76e-4107-a42b-cce80ef5753a"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("a647ff5c-d1fe-4dd9-b503-9181b769eb47"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("b20148c7-e6d2-4621-9fd6-34309ad44f24"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("bbe8bff1-b756-4dfd-a819-23f24c215408"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("c6f885eb-fae8-4c07-b6dd-2d2a5b7015e1"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("c87b313c-f63f-45fc-9bd9-84ab3020531b"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("d045cd15-6d0c-4c47-b4d9-20a9e9ab681c"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("da47aa8a-413e-48b9-8438-f37ee05bd3bb"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("de14c71c-9f44-4c30-96e4-b2ea81fb0670"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("e463bd58-27d0-4040-9161-2eff4c0167ab"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("f3f4bf24-da71-407d-ad16-30596b649c5e"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("f6287bec-d4b1-4112-8fc3-174620a37896"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("fec928d8-adc1-4e4e-84b0-74064865f0b2"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "TargetValue",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Achievements");

            migrationBuilder.AddColumn<Guid>(
                name: "SquadId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AthleteDataId",
                table: "Achievements",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoachDataId",
                table: "Achievements",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoachDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_CoachDatas_CoachDataOwnerId",
                        column: x => x.CoachDataOwnerId,
                        principalTable: "CoachDatas",
                        principalColumn: "CoachDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "AthleteDataAward",
                columns: table => new
                {
                    AwardsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteDataAward", x => new { x.AwardsId, x.RecipientsId });
                    table.ForeignKey(
                        name: "FK_AthleteDataAward_AthleteDatas_RecipientsId",
                        column: x => x.RecipientsId,
                        principalTable: "AthleteDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteDataAward_Awards_AwardsId",
                        column: x => x.AwardsId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squads_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SquadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timetables_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoachDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimetableId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_CoachDatas_CoachDataOwnerId",
                        column: x => x.CoachDataOwnerId,
                        principalTable: "CoachDatas",
                        principalColumn: "CoachDataId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetItems_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SquadId",
                table: "Users",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_AthleteDataId",
                table: "Achievements",
                column: "AthleteDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_CoachDataId",
                table: "Achievements",
                column: "CoachDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteDataAward_RecipientsId",
                table: "AthleteDataAward",
                column: "RecipientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_CoachDataOwnerId",
                table: "Awards",
                column: "CoachDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CoachDataOwnerId",
                table: "Sessions",
                column: "CoachDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TimetableId",
                table: "Sessions",
                column: "TimetableId");

            migrationBuilder.CreateIndex(
                name: "IX_SetItems_SetId",
                table: "SetItems",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_SessionId",
                table: "Sets",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_ClubId",
                table: "Squads",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_SquadId",
                table: "Timetables",
                column: "SquadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AthleteDatas_AthleteDataId",
                table: "Achievements",
                column: "AthleteDataId",
                principalTable: "AthleteDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_CoachDatas_CoachDataId",
                table: "Achievements",
                column: "CoachDataId",
                principalTable: "CoachDatas",
                principalColumn: "CoachDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Squads_SquadId",
                table: "Users",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id");
        }
    }
}

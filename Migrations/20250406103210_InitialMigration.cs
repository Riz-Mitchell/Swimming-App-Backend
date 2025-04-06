using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AthleteDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MainStroke = table.Column<string>(type: "text", nullable: true),
                    MainDistance = table.Column<int>(type: "integer", nullable: true),
                    GoalTime = table.Column<string>(type: "text", nullable: true),
                    UserOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteDatas", x => x.Id);
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
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AthleteDataId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoachDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_AthleteDatas_AthleteDataId",
                        column: x => x.AthleteDataId,
                        principalTable: "AthleteDatas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Achievements_CoachDatas_CoachDataId",
                        column: x => x.CoachDataId,
                        principalTable: "CoachDatas",
                        principalColumn: "CoachDataId");
                });

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
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    TimeSheetId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "TimeSheetsItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false),
                    CurrentInterval = table.Column<double>(type: "double precision", nullable: false),
                    TimeSheetId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SquadId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTables_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SquadId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "FK_Users_CoachDatas_AthleteDataId",
                        column: x => x.AthleteDataId,
                        principalTable: "CoachDatas",
                        principalColumn: "CoachDataId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
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
                name: "GoalSwims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false),
                    StrokeRate = table.Column<int>(type: "integer", nullable: true),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    AthleteDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Swims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoalTime = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<double>(type: "double precision", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    StrokeRate = table.Column<int>(type: "integer", nullable: true),
                    Pace = table.Column<int>(type: "integer", nullable: true),
                    PerceivedExertion = table.Column<int>(type: "integer", nullable: true),
                    Dive = table.Column<bool>(type: "boolean", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_Swims_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeTableId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoachDataOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_Sessions_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
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

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CoachDataOwnerId",
                table: "Sessions",
                column: "CoachDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TimeTableId",
                table: "Sessions",
                column: "TimeTableId");

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
                name: "IX_Swims_AthleteDataOwnerId",
                table: "Swims",
                column: "AthleteDataOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Swims_EventId",
                table: "Swims",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetsItems_TimeSheetId",
                table: "TimeSheetsItems",
                column: "TimeSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SquadId",
                table: "TimeTables",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AthleteDataId",
                table: "Users",
                column: "AthleteDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SquadId",
                table: "Users",
                column: "SquadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "AthleteDataAward");

            migrationBuilder.DropTable(
                name: "GoalSwims");

            migrationBuilder.DropTable(
                name: "SetItems");

            migrationBuilder.DropTable(
                name: "Swims");

            migrationBuilder.DropTable(
                name: "TimeSheetsItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AthleteDatas");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "CoachDatas");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}

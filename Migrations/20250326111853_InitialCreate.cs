using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ClubId = table.Column<int>(type: "integer", nullable: true)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SquadId = table.Column<int>(type: "integer", nullable: true),
                    SwimmerDataId = table.Column<int>(type: "integer", nullable: true),
                    CoachDataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoachDatas",
                columns: table => new
                {
                    CoachDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserOwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachDatas", x => x.CoachDataId);
                    table.ForeignKey(
                        name: "FK_CoachDatas_Users_UserOwnerId",
                        column: x => x.UserOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwimmerDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainStroke = table.Column<string>(type: "text", nullable: true),
                    MainDistance = table.Column<int>(type: "integer", nullable: true),
                    GoalTime = table.Column<string>(type: "text", nullable: true),
                    UserOwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmerDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwimmerDatas_Users_UserOwnerId",
                        column: x => x.UserOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Swims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    StrokeRate = table.Column<int>(type: "integer", nullable: true),
                    Pace = table.Column<int>(type: "integer", nullable: true),
                    perceivedExertion = table.Column<int>(type: "integer", nullable: true),
                    dive = table.Column<bool>(type: "boolean", nullable: false),
                    SwimmerDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swims_SwimmerDatas_SwimmerDataId",
                        column: x => x.SwimmerDataId,
                        principalTable: "SwimmerDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Stroke = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    StrokeRate = table.Column<int>(type: "integer", nullable: true),
                    Pace = table.Column<int>(type: "integer", nullable: true),
                    perceivedExertion = table.Column<int>(type: "integer", nullable: true),
                    dive = table.Column<bool>(type: "boolean", nullable: false),
                    SwimId = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_CoachDatas_UserOwnerId",
                table: "CoachDatas",
                column: "UserOwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Splits_SwimId",
                table: "Splits",
                column: "SwimId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_ClubId",
                table: "Squads",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimmerDatas_UserOwnerId",
                table: "SwimmerDatas",
                column: "UserOwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Swims_SwimmerDataId",
                table: "Swims",
                column: "SwimmerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SquadId",
                table: "Users",
                column: "SquadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachDatas");

            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropTable(
                name: "Swims");

            migrationBuilder.DropTable(
                name: "SwimmerDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}

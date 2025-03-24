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
                name: "Club",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phoneNum = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoachProfile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachProfile", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoachProfile_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coachId = table.Column<int>(type: "integer", nullable: false),
                    clubId = table.Column<int>(type: "integer", nullable: true),
                    squadName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Squad_Club_clubId",
                        column: x => x.clubId,
                        principalTable: "Club",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Squad_CoachProfile_coachId",
                        column: x => x.coachId,
                        principalTable: "CoachProfile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    squadId = table.Column<int>(type: "integer", nullable: false),
                    quoteOfTheSet = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.id);
                    table.ForeignKey(
                        name: "FK_Set_Squad_squadId",
                        column: x => x.squadId,
                        principalTable: "Squad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwimmerProfile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    squadId = table.Column<int>(type: "integer", nullable: true),
                    mainStroke = table.Column<string>(type: "text", nullable: true),
                    mainDistance = table.Column<int>(type: "integer", nullable: true),
                    goalTime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmerProfile", x => x.id);
                    table.ForeignKey(
                        name: "FK_SwimmerProfile_Squad_squadId",
                        column: x => x.squadId,
                        principalTable: "Squad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SwimmerProfile_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Swim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    swimmerProfileId = table.Column<int>(type: "integer", nullable: false),
                    stroke = table.Column<string>(type: "text", nullable: false),
                    distance = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    strokeRate = table.Column<int>(type: "integer", nullable: true),
                    pace = table.Column<int>(type: "integer", nullable: true),
                    perceivedExertion = table.Column<int>(type: "integer", nullable: true),
                    heartRate = table.Column<int>(type: "integer", nullable: true),
                    dive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swim", x => x.id);
                    table.ForeignKey(
                        name: "FK_Swim_SwimmerProfile_swimmerProfileId",
                        column: x => x.swimmerProfileId,
                        principalTable: "SwimmerProfile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Split",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    swimId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: true),
                    strokeRate = table.Column<int>(type: "integer", nullable: true),
                    stroke = table.Column<string>(type: "text", nullable: false),
                    distance = table.Column<int>(type: "integer", nullable: true),
                    pace = table.Column<int>(type: "integer", nullable: true),
                    perceivedExertion = table.Column<int>(type: "integer", nullable: true),
                    dive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Split", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Split_Swim_swimId",
                        column: x => x.swimId,
                        principalTable: "Swim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachProfile_userId",
                table: "CoachProfile",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Set_squadId",
                table: "Set",
                column: "squadId");

            migrationBuilder.CreateIndex(
                name: "IX_Split_swimId",
                table: "Split",
                column: "swimId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_clubId",
                table: "Squad",
                column: "clubId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_coachId",
                table: "Squad",
                column: "coachId");

            migrationBuilder.CreateIndex(
                name: "IX_Swim_swimmerProfileId",
                table: "Swim",
                column: "swimmerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimmerProfile_squadId",
                table: "SwimmerProfile",
                column: "squadId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimmerProfile_userId",
                table: "SwimmerProfile",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.DropTable(
                name: "Split");

            migrationBuilder.DropTable(
                name: "Swim");

            migrationBuilder.DropTable(
                name: "SwimmerProfile");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "CoachProfile");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

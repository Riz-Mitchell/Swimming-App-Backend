using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class Added_Squad_Set_and_Coach_Support : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "squadId",
                table: "SwimmerProfile",
                type: "integer",
                nullable: true);

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
                    squadName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.id);
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

            migrationBuilder.CreateIndex(
                name: "IX_SwimmerProfile_squadId",
                table: "SwimmerProfile",
                column: "squadId");

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
                name: "IX_Squad_coachId",
                table: "Squad",
                column: "coachId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwimmerProfile_Squad_squadId",
                table: "SwimmerProfile",
                column: "squadId",
                principalTable: "Squad",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwimmerProfile_Squad_squadId",
                table: "SwimmerProfile");

            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropTable(
                name: "CoachProfile");

            migrationBuilder.DropIndex(
                name: "IX_SwimmerProfile_squadId",
                table: "SwimmerProfile");

            migrationBuilder.DropColumn(
                name: "squadId",
                table: "SwimmerProfile");
        }
    }
}

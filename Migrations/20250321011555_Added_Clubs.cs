using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class Added_Clubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clubId",
                table: "Squad",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Squad_clubId",
                table: "Squad",
                column: "clubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Club_clubId",
                table: "Squad",
                column: "clubId",
                principalTable: "Club",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Club_clubId",
                table: "Squad");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Squad_clubId",
                table: "Squad");

            migrationBuilder.DropColumn(
                name: "clubId",
                table: "Squad");
        }
    }
}

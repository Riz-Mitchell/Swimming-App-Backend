using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class TestingSomeDifferentSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SwimmerId",
                table: "Swims",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Swimmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNum = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swimmers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Swims_SwimmerId",
                table: "Swims",
                column: "SwimmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims",
                column: "SwimmerId",
                principalTable: "Swimmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims");

            migrationBuilder.DropTable(
                name: "Swimmers");

            migrationBuilder.DropIndex(
                name: "IX_Swims_SwimmerId",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "SwimmerId",
                table: "Swims");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class ActuallyFixedTheAttributesNoteShowingInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "goalTime",
                table: "SwimmerProfile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mainDistance",
                table: "SwimmerProfile",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mainStroke",
                table: "SwimmerProfile",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "goalTime",
                table: "SwimmerProfile");

            migrationBuilder.DropColumn(
                name: "mainDistance",
                table: "SwimmerProfile");

            migrationBuilder.DropColumn(
                name: "mainStroke",
                table: "SwimmerProfile");
        }
    }
}

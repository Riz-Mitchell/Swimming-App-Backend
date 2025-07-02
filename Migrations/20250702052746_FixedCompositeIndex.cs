using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixedCompositeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber_Id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber_Id",
                table: "Users",
                columns: new[] { "PhoneNumber", "Id" },
                unique: true);
        }
    }
}

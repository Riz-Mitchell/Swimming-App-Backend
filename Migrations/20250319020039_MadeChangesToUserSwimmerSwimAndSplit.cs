using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class MadeChangesToUserSwimmerSwimAndSplit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swimmers",
                table: "Swimmers");

            migrationBuilder.RenameTable(
                name: "Swimmers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "SwimmerId",
                table: "Swims",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Swims_SwimmerId",
                table: "Swims",
                newName: "IX_Swims_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Users_UserId",
                table: "Swims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Users_UserId",
                table: "Swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Swimmers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Swims",
                newName: "SwimmerId");

            migrationBuilder.RenameIndex(
                name: "IX_Swims_UserId",
                table: "Swims",
                newName: "IX_Swims_SwimmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swimmers",
                table: "Swimmers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims",
                column: "SwimmerId",
                principalTable: "Swimmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

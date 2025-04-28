using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixedNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CoachDatas_AthleteDataId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CoachDataId",
                table: "Users",
                column: "CoachDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CoachDatas_CoachDataId",
                table: "Users",
                column: "CoachDataId",
                principalTable: "CoachDatas",
                principalColumn: "CoachDataId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CoachDatas_CoachDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CoachDataId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CoachDatas_AthleteDataId",
                table: "Users",
                column: "AthleteDataId",
                principalTable: "CoachDatas",
                principalColumn: "CoachDataId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

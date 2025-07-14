using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class MadeChangesToAthleteDataModelAndSwimModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Swims",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExternalSource",
                table: "Swims",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExternal",
                table: "Swims",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PoolType",
                table: "Swims",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "ExternalSource",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "IsExternal",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "PoolType",
                table: "Swims");
        }
    }
}

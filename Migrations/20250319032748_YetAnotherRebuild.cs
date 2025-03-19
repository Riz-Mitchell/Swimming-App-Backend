using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SwimmingAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class YetAnotherRebuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Splits_Swims_SwimId",
                table: "Splits");

            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Users_UserId",
                table: "Swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swims",
                table: "Swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Splits",
                table: "Splits");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Swims",
                newName: "Swim");

            migrationBuilder.RenameTable(
                name: "Splits",
                newName: "Split");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "User",
                newName: "phoneNum");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "User",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Swim",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "StrokeRate",
                table: "Swim",
                newName: "strokeRate");

            migrationBuilder.RenameColumn(
                name: "Stroke",
                table: "Swim",
                newName: "stroke");

            migrationBuilder.RenameColumn(
                name: "PerceivedExertion",
                table: "Swim",
                newName: "perceivedExertion");

            migrationBuilder.RenameColumn(
                name: "Pace",
                table: "Swim",
                newName: "pace");

            migrationBuilder.RenameColumn(
                name: "HeartRate",
                table: "Swim",
                newName: "heartRate");

            migrationBuilder.RenameColumn(
                name: "Dive",
                table: "Swim",
                newName: "dive");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Swim",
                newName: "distance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Swim",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Swim",
                newName: "swimmerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Swims_UserId",
                table: "Swim",
                newName: "IX_Swim_swimmerProfileId");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Split",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "SwimId",
                table: "Split",
                newName: "swimId");

            migrationBuilder.RenameColumn(
                name: "StrokeRate",
                table: "Split",
                newName: "strokeRate");

            migrationBuilder.RenameColumn(
                name: "Stroke",
                table: "Split",
                newName: "stroke");

            migrationBuilder.RenameColumn(
                name: "PerceivedExertion",
                table: "Split",
                newName: "perceivedExertion");

            migrationBuilder.RenameColumn(
                name: "Pace",
                table: "Split",
                newName: "pace");

            migrationBuilder.RenameColumn(
                name: "Dive",
                table: "Split",
                newName: "dive");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Split",
                newName: "distance");

            migrationBuilder.RenameIndex(
                name: "IX_Splits_SwimId",
                table: "Split",
                newName: "IX_Split_swimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swim",
                table: "Swim",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Split",
                table: "Split",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SwimmerProfile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmerProfile", x => x.id);
                    table.ForeignKey(
                        name: "FK_SwimmerProfile_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwimmerProfile_userId",
                table: "SwimmerProfile",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Split_Swim_swimId",
                table: "Split",
                column: "swimId",
                principalTable: "Swim",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Swim_SwimmerProfile_swimmerProfileId",
                table: "Swim",
                column: "swimmerProfileId",
                principalTable: "SwimmerProfile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Split_Swim_swimId",
                table: "Split");

            migrationBuilder.DropForeignKey(
                name: "FK_Swim_SwimmerProfile_swimmerProfileId",
                table: "Swim");

            migrationBuilder.DropTable(
                name: "SwimmerProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swim",
                table: "Swim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Split",
                table: "Split");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Swim",
                newName: "Swims");

            migrationBuilder.RenameTable(
                name: "Split",
                newName: "Splits");

            migrationBuilder.RenameColumn(
                name: "phoneNum",
                table: "Users",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Users",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Swims",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "strokeRate",
                table: "Swims",
                newName: "StrokeRate");

            migrationBuilder.RenameColumn(
                name: "stroke",
                table: "Swims",
                newName: "Stroke");

            migrationBuilder.RenameColumn(
                name: "perceivedExertion",
                table: "Swims",
                newName: "PerceivedExertion");

            migrationBuilder.RenameColumn(
                name: "pace",
                table: "Swims",
                newName: "Pace");

            migrationBuilder.RenameColumn(
                name: "heartRate",
                table: "Swims",
                newName: "HeartRate");

            migrationBuilder.RenameColumn(
                name: "dive",
                table: "Swims",
                newName: "Dive");

            migrationBuilder.RenameColumn(
                name: "distance",
                table: "Swims",
                newName: "Distance");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Swims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "swimmerProfileId",
                table: "Swims",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Swim_swimmerProfileId",
                table: "Swims",
                newName: "IX_Swims_UserId");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Splits",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "swimId",
                table: "Splits",
                newName: "SwimId");

            migrationBuilder.RenameColumn(
                name: "strokeRate",
                table: "Splits",
                newName: "StrokeRate");

            migrationBuilder.RenameColumn(
                name: "stroke",
                table: "Splits",
                newName: "Stroke");

            migrationBuilder.RenameColumn(
                name: "perceivedExertion",
                table: "Splits",
                newName: "PerceivedExertion");

            migrationBuilder.RenameColumn(
                name: "pace",
                table: "Splits",
                newName: "Pace");

            migrationBuilder.RenameColumn(
                name: "dive",
                table: "Splits",
                newName: "Dive");

            migrationBuilder.RenameColumn(
                name: "distance",
                table: "Splits",
                newName: "Distance");

            migrationBuilder.RenameIndex(
                name: "IX_Split_swimId",
                table: "Splits",
                newName: "IX_Splits_SwimId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swims",
                table: "Swims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Splits",
                table: "Splits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Splits_Swims_SwimId",
                table: "Splits",
                column: "SwimId",
                principalTable: "Swims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Users_UserId",
                table: "Swims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

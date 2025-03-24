using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedGettersAndSetters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachProfile_User_userId",
                table: "CoachProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Set_Squad_squadId",
                table: "Set");

            migrationBuilder.DropForeignKey(
                name: "FK_Split_Swim_swimId",
                table: "Split");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Club_clubId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_CoachProfile_coachId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_Swim_SwimmerProfile_swimmerProfileId",
                table: "Swim");

            migrationBuilder.DropForeignKey(
                name: "FK_SwimmerProfile_Squad_squadId",
                table: "SwimmerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_SwimmerProfile_User_userId",
                table: "SwimmerProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SwimmerProfile",
                table: "SwimmerProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swim",
                table: "Swim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squad",
                table: "Squad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Split",
                table: "Split");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Set",
                table: "Set");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachProfile",
                table: "CoachProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "SwimmerProfile",
                newName: "swimmerProfiles");

            migrationBuilder.RenameTable(
                name: "Swim",
                newName: "swims");

            migrationBuilder.RenameTable(
                name: "Squad",
                newName: "squads");

            migrationBuilder.RenameTable(
                name: "Split",
                newName: "splits");

            migrationBuilder.RenameTable(
                name: "Set",
                newName: "sets");

            migrationBuilder.RenameTable(
                name: "CoachProfile",
                newName: "coachProfiles");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "clubs");

            migrationBuilder.RenameIndex(
                name: "IX_SwimmerProfile_userId",
                table: "swimmerProfiles",
                newName: "IX_swimmerProfiles_userId");

            migrationBuilder.RenameIndex(
                name: "IX_SwimmerProfile_squadId",
                table: "swimmerProfiles",
                newName: "IX_swimmerProfiles_squadId");

            migrationBuilder.RenameIndex(
                name: "IX_Swim_swimmerProfileId",
                table: "swims",
                newName: "IX_swims_swimmerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Squad_coachId",
                table: "squads",
                newName: "IX_squads_coachId");

            migrationBuilder.RenameIndex(
                name: "IX_Squad_clubId",
                table: "squads",
                newName: "IX_squads_clubId");

            migrationBuilder.RenameIndex(
                name: "IX_Split_swimId",
                table: "splits",
                newName: "IX_splits_swimId");

            migrationBuilder.RenameIndex(
                name: "IX_Set_squadId",
                table: "sets",
                newName: "IX_sets_squadId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachProfile_userId",
                table: "coachProfiles",
                newName: "IX_coachProfiles_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_swimmerProfiles",
                table: "swimmerProfiles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_swims",
                table: "swims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_squads",
                table: "squads",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_splits",
                table: "splits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sets",
                table: "sets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_coachProfiles",
                table: "coachProfiles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clubs",
                table: "clubs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_coachProfiles_users_userId",
                table: "coachProfiles",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sets_squads_squadId",
                table: "sets",
                column: "squadId",
                principalTable: "squads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_splits_swims_swimId",
                table: "splits",
                column: "swimId",
                principalTable: "swims",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_squads_clubs_clubId",
                table: "squads",
                column: "clubId",
                principalTable: "clubs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_squads_coachProfiles_coachId",
                table: "squads",
                column: "coachId",
                principalTable: "coachProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_swimmerProfiles_squads_squadId",
                table: "swimmerProfiles",
                column: "squadId",
                principalTable: "squads",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_swimmerProfiles_users_userId",
                table: "swimmerProfiles",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_swims_swimmerProfiles_swimmerProfileId",
                table: "swims",
                column: "swimmerProfileId",
                principalTable: "swimmerProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coachProfiles_users_userId",
                table: "coachProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_sets_squads_squadId",
                table: "sets");

            migrationBuilder.DropForeignKey(
                name: "FK_splits_swims_swimId",
                table: "splits");

            migrationBuilder.DropForeignKey(
                name: "FK_squads_clubs_clubId",
                table: "squads");

            migrationBuilder.DropForeignKey(
                name: "FK_squads_coachProfiles_coachId",
                table: "squads");

            migrationBuilder.DropForeignKey(
                name: "FK_swimmerProfiles_squads_squadId",
                table: "swimmerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_swimmerProfiles_users_userId",
                table: "swimmerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_swims_swimmerProfiles_swimmerProfileId",
                table: "swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_swims",
                table: "swims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_swimmerProfiles",
                table: "swimmerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_squads",
                table: "squads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_splits",
                table: "splits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sets",
                table: "sets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_coachProfiles",
                table: "coachProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clubs",
                table: "clubs");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "swims",
                newName: "Swim");

            migrationBuilder.RenameTable(
                name: "swimmerProfiles",
                newName: "SwimmerProfile");

            migrationBuilder.RenameTable(
                name: "squads",
                newName: "Squad");

            migrationBuilder.RenameTable(
                name: "splits",
                newName: "Split");

            migrationBuilder.RenameTable(
                name: "sets",
                newName: "Set");

            migrationBuilder.RenameTable(
                name: "coachProfiles",
                newName: "CoachProfile");

            migrationBuilder.RenameTable(
                name: "clubs",
                newName: "Club");

            migrationBuilder.RenameIndex(
                name: "IX_swims_swimmerProfileId",
                table: "Swim",
                newName: "IX_Swim_swimmerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_swimmerProfiles_userId",
                table: "SwimmerProfile",
                newName: "IX_SwimmerProfile_userId");

            migrationBuilder.RenameIndex(
                name: "IX_swimmerProfiles_squadId",
                table: "SwimmerProfile",
                newName: "IX_SwimmerProfile_squadId");

            migrationBuilder.RenameIndex(
                name: "IX_squads_coachId",
                table: "Squad",
                newName: "IX_Squad_coachId");

            migrationBuilder.RenameIndex(
                name: "IX_squads_clubId",
                table: "Squad",
                newName: "IX_Squad_clubId");

            migrationBuilder.RenameIndex(
                name: "IX_splits_swimId",
                table: "Split",
                newName: "IX_Split_swimId");

            migrationBuilder.RenameIndex(
                name: "IX_sets_squadId",
                table: "Set",
                newName: "IX_Set_squadId");

            migrationBuilder.RenameIndex(
                name: "IX_coachProfiles_userId",
                table: "CoachProfile",
                newName: "IX_CoachProfile_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swim",
                table: "Swim",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SwimmerProfile",
                table: "SwimmerProfile",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squad",
                table: "Squad",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Split",
                table: "Split",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Set",
                table: "Set",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachProfile",
                table: "CoachProfile",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachProfile_User_userId",
                table: "CoachProfile",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Set_Squad_squadId",
                table: "Set",
                column: "squadId",
                principalTable: "Squad",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Split_Swim_swimId",
                table: "Split",
                column: "swimId",
                principalTable: "Swim",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Club_clubId",
                table: "Squad",
                column: "clubId",
                principalTable: "Club",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_CoachProfile_coachId",
                table: "Squad",
                column: "coachId",
                principalTable: "CoachProfile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Swim_SwimmerProfile_swimmerProfileId",
                table: "Swim",
                column: "swimmerProfileId",
                principalTable: "SwimmerProfile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SwimmerProfile_Squad_squadId",
                table: "SwimmerProfile",
                column: "squadId",
                principalTable: "Squad",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SwimmerProfile_User_userId",
                table: "SwimmerProfile",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

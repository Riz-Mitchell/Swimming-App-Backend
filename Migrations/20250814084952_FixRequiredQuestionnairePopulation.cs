using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixRequiredQuestionnairePopulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO ""SwimQuestionnaire"" (""Id"", ""SelfTalk"", ""Nerves"", ""EnergyLevel"", ""Breathing"", ""CatchFeel"", ""StrokeLength"", ""KickTechnique"", ""KickThroughout"", ""HeadPosition"", ""Turn"")
                SELECT gen_random_uuid(),
                    0,  -- SelfTalkOptionsEnum.unselected
                    ARRAY[0]::int[],  -- NervesOptionsEnum unselected
                    0,  -- EnergyLevelOptionsEnum.unselected
                    0,  -- BreathingOptionsEnum.unselected
                    ARRAY[0]::int[],  -- CatchFeelOptionsEnum unselected
                    0,  -- StrokeLengthOptionsEnum.unselected
                    0,  -- KickTechniqueOptionsEnum.unselected
                    0,  -- KickThroughoutOptionsEnum.unselected
                    ARRAY[0]::int[],  -- HeadPositionOptionsEnum unselected
                    ARRAY[0]::int[]   -- TurnOptionsEnum unselected
                FROM ""Swims""
                WHERE ""SwimQuestionnaireId"" IS NULL OR ""SwimQuestionnaireId"" = '00000000-0000-0000-0000-000000000000';
            ");

            migrationBuilder.Sql(@"
                UPDATE ""Swims"" s
                SET ""SwimQuestionnaireId"" = q.""Id""
                FROM ""SwimQuestionnaire"" q
                WHERE (s.""SwimQuestionnaireId"" IS NULL OR s.""SwimQuestionnaireId"" = '00000000-0000-0000-0000-000000000000')
                AND q.""Id"" NOT IN (SELECT ""SwimQuestionnaireId"" FROM ""Swims"" WHERE ""SwimQuestionnaireId"" IS NOT NULL)
                LIMIT 1;
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_SwimQuestionnaire_SwimQuestionnaireId",
                table: "Swims",
                column: "SwimQuestionnaireId",
                principalTable: "SwimQuestionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

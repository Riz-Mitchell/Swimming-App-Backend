using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swimming_App_Backend.Migrations
{
    /// <inheritdoc />
    public partial class MadeQuestionnaireValuesMultiSelectable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:breathing_options_enum", "unselected,normal,fast,deep,erratic")
                .Annotation("Npgsql:Enum:catch_feel_options_enum", "unselected,strong,weak,slipping,wide,narrow")
                .Annotation("Npgsql:Enum:energy_level_options_enum", "unselected,low,moderate,high,very_high")
                .Annotation("Npgsql:Enum:head_position_options_enum", "unselected,looking_forward,looking_down,head_high,head_low,head_neutral")
                .Annotation("Npgsql:Enum:kick_technique_options_enum", "unselected,small,big")
                .Annotation("Npgsql:Enum:kick_throughout_options_enum", "unselected,consistent,speeding_up,slowing_down")
                .Annotation("Npgsql:Enum:nerves_options_enum", "unselected,relaxed,jittery,tense,heavy,light,nauseous")
                .Annotation("Npgsql:Enum:self_talk_options_enum", "unselected,none,motivational_positive,motivational_negative,instructive_positive,instructive_negative,outcome_positive,outcome_negative")
                .Annotation("Npgsql:Enum:stroke_length_options_enum", "unselected,longer,shorter")
                .Annotation("Npgsql:Enum:turn_options_enum", "unselected,good,too_far,too_close,felt_slow,felt_fast");

            migrationBuilder.Sql(@"
                ALTER TABLE ""SwimQuestionnaire""
                ALTER COLUMN ""Turn"" TYPE integer[]
                USING ARRAY[""Turn""];
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""SwimQuestionnaire""
                ALTER COLUMN ""Nerves"" TYPE integer[]
                USING ARRAY[""Nerves""];
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""SwimQuestionnaire""
                ALTER COLUMN ""HeadPosition"" TYPE integer[]
                USING ARRAY[""HeadPosition""];
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""SwimQuestionnaire""
                ALTER COLUMN ""CatchFeel"" TYPE integer[]
                USING ARRAY[""CatchFeel""];
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:breathing_options_enum", "unselected,normal,fast,deep,erratic")
                .OldAnnotation("Npgsql:Enum:catch_feel_options_enum", "unselected,strong,weak,slipping,wide,narrow")
                .OldAnnotation("Npgsql:Enum:energy_level_options_enum", "unselected,low,moderate,high,very_high")
                .OldAnnotation("Npgsql:Enum:head_position_options_enum", "unselected,looking_forward,looking_down,head_high,head_low,head_neutral")
                .OldAnnotation("Npgsql:Enum:kick_technique_options_enum", "unselected,small,big")
                .OldAnnotation("Npgsql:Enum:kick_throughout_options_enum", "unselected,consistent,speeding_up,slowing_down")
                .OldAnnotation("Npgsql:Enum:nerves_options_enum", "unselected,relaxed,jittery,tense,heavy,light,nauseous")
                .OldAnnotation("Npgsql:Enum:self_talk_options_enum", "unselected,none,motivational_positive,motivational_negative,instructive_positive,instructive_negative,outcome_positive,outcome_negative")
                .OldAnnotation("Npgsql:Enum:stroke_length_options_enum", "unselected,longer,shorter")
                .OldAnnotation("Npgsql:Enum:turn_options_enum", "unselected,good,too_far,too_close,felt_slow,felt_fast");

            migrationBuilder.AlterColumn<int>(
                name: "Turn",
                table: "SwimQuestionnaire",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<int>(
                name: "Nerves",
                table: "SwimQuestionnaire",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<int>(
                name: "HeadPosition",
                table: "SwimQuestionnaire",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<int>(
                name: "CatchFeel",
                table: "SwimQuestionnaire",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");
        }
    }
}

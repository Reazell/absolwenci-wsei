using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migrassss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "OpenQuestions");

            migrationBuilder.DropColumn(
                name: "MarkedAnswersNames",
                table: "MultipleChoices");

            migrationBuilder.DropColumn(
                name: "MarkedValue",
                table: "LinearScales");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SingleGrids",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "MultipleGrids",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "MarkedAnswer",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkedAnswers",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkedCol",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkedCols",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarkedValue",
                table: "Answer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rows",
                table: "Answer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkedAnswer",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "MarkedAnswers",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "MarkedCol",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "MarkedCols",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "MarkedValue",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "Rows",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "SingleGrids",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "MultipleGrids",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "OpenQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkedAnswersNames",
                table: "MultipleChoices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarkedValue",
                table: "LinearScales",
                nullable: false,
                defaultValue: 0);
        }
    }
}

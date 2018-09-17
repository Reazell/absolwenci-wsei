using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migrationz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceOptionsAnswers_FieldDataAnswers_FieldDataAnswerId",
                table: "ChoiceOptionsAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceOptionsAnswers_FieldDataAnswers_FieldDataAnswerId",
                table: "ChoiceOptionsAnswers",
                column: "FieldDataAnswerId",
                principalTable: "FieldDataAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceOptionsAnswers_FieldDataAnswers_FieldDataAnswerId",
                table: "ChoiceOptionsAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceOptionsAnswers_FieldDataAnswers_FieldDataAnswerId",
                table: "ChoiceOptionsAnswers",
                column: "FieldDataAnswerId",
                principalTable: "FieldDataAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

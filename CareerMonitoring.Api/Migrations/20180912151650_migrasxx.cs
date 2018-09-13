using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migrasxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinearScaleAnswer_LinearScales_QuestionId",
                table: "LinearScaleAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceAnswer_MultipleChoices_QuestionId",
                table: "MultipleChoiceAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleGridAnswer_MultipleGrids_QuestionId",
                table: "MultipleGridAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenQuestionAnswer_OpenQuestions_QuestionId",
                table: "OpenQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleChoiceAnswer_SingleChoices_QuestionId",
                table: "SingleChoiceAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleGridAnswer_SingleGrids_QuestionId",
                table: "SingleGridAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleGridAnswer",
                table: "SingleGridAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleChoiceAnswer",
                table: "SingleChoiceAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenQuestionAnswer",
                table: "OpenQuestionAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleGridAnswer",
                table: "MultipleGridAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceAnswer",
                table: "MultipleChoiceAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinearScaleAnswer",
                table: "LinearScaleAnswer");

            migrationBuilder.RenameTable(
                name: "SingleGridAnswer",
                newName: "SingleGridsAnswers");

            migrationBuilder.RenameTable(
                name: "SingleChoiceAnswer",
                newName: "SingleChoicesAnswers");

            migrationBuilder.RenameTable(
                name: "OpenQuestionAnswer",
                newName: "OpenQuestionsAnswers");

            migrationBuilder.RenameTable(
                name: "MultipleGridAnswer",
                newName: "MultipleGridsAnswers");

            migrationBuilder.RenameTable(
                name: "MultipleChoiceAnswer",
                newName: "MultipleChoicesAnswers");

            migrationBuilder.RenameTable(
                name: "LinearScaleAnswer",
                newName: "LinearScalesAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_SingleGridAnswer_QuestionId",
                table: "SingleGridsAnswers",
                newName: "IX_SingleGridsAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SingleChoiceAnswer_QuestionId",
                table: "SingleChoicesAnswers",
                newName: "IX_SingleChoicesAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenQuestionAnswer_QuestionId",
                table: "OpenQuestionsAnswers",
                newName: "IX_OpenQuestionsAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleGridAnswer_QuestionId",
                table: "MultipleGridsAnswers",
                newName: "IX_MultipleGridsAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoiceAnswer_QuestionId",
                table: "MultipleChoicesAnswers",
                newName: "IX_MultipleChoicesAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_LinearScaleAnswer_QuestionId",
                table: "LinearScalesAnswers",
                newName: "IX_LinearScalesAnswers_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleGridsAnswers",
                table: "SingleGridsAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleChoicesAnswers",
                table: "SingleChoicesAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenQuestionsAnswers",
                table: "OpenQuestionsAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleGridsAnswers",
                table: "MultipleGridsAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoicesAnswers",
                table: "MultipleChoicesAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinearScalesAnswers",
                table: "LinearScalesAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinearScalesAnswers_LinearScales_QuestionId",
                table: "LinearScalesAnswers",
                column: "QuestionId",
                principalTable: "LinearScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoicesAnswers_MultipleChoices_QuestionId",
                table: "MultipleChoicesAnswers",
                column: "QuestionId",
                principalTable: "MultipleChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleGridsAnswers_MultipleGrids_QuestionId",
                table: "MultipleGridsAnswers",
                column: "QuestionId",
                principalTable: "MultipleGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenQuestionsAnswers_OpenQuestions_QuestionId",
                table: "OpenQuestionsAnswers",
                column: "QuestionId",
                principalTable: "OpenQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleChoicesAnswers_SingleChoices_QuestionId",
                table: "SingleChoicesAnswers",
                column: "QuestionId",
                principalTable: "SingleChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleGridsAnswers_SingleGrids_QuestionId",
                table: "SingleGridsAnswers",
                column: "QuestionId",
                principalTable: "SingleGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinearScalesAnswers_LinearScales_QuestionId",
                table: "LinearScalesAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoicesAnswers_MultipleChoices_QuestionId",
                table: "MultipleChoicesAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleGridsAnswers_MultipleGrids_QuestionId",
                table: "MultipleGridsAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenQuestionsAnswers_OpenQuestions_QuestionId",
                table: "OpenQuestionsAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleChoicesAnswers_SingleChoices_QuestionId",
                table: "SingleChoicesAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleGridsAnswers_SingleGrids_QuestionId",
                table: "SingleGridsAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleGridsAnswers",
                table: "SingleGridsAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleChoicesAnswers",
                table: "SingleChoicesAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenQuestionsAnswers",
                table: "OpenQuestionsAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleGridsAnswers",
                table: "MultipleGridsAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoicesAnswers",
                table: "MultipleChoicesAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinearScalesAnswers",
                table: "LinearScalesAnswers");

            migrationBuilder.RenameTable(
                name: "SingleGridsAnswers",
                newName: "SingleGridAnswer");

            migrationBuilder.RenameTable(
                name: "SingleChoicesAnswers",
                newName: "SingleChoiceAnswer");

            migrationBuilder.RenameTable(
                name: "OpenQuestionsAnswers",
                newName: "OpenQuestionAnswer");

            migrationBuilder.RenameTable(
                name: "MultipleGridsAnswers",
                newName: "MultipleGridAnswer");

            migrationBuilder.RenameTable(
                name: "MultipleChoicesAnswers",
                newName: "MultipleChoiceAnswer");

            migrationBuilder.RenameTable(
                name: "LinearScalesAnswers",
                newName: "LinearScaleAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_SingleGridsAnswers_QuestionId",
                table: "SingleGridAnswer",
                newName: "IX_SingleGridAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SingleChoicesAnswers_QuestionId",
                table: "SingleChoiceAnswer",
                newName: "IX_SingleChoiceAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenQuestionsAnswers_QuestionId",
                table: "OpenQuestionAnswer",
                newName: "IX_OpenQuestionAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleGridsAnswers_QuestionId",
                table: "MultipleGridAnswer",
                newName: "IX_MultipleGridAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoicesAnswers_QuestionId",
                table: "MultipleChoiceAnswer",
                newName: "IX_MultipleChoiceAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_LinearScalesAnswers_QuestionId",
                table: "LinearScaleAnswer",
                newName: "IX_LinearScaleAnswer_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleGridAnswer",
                table: "SingleGridAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleChoiceAnswer",
                table: "SingleChoiceAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenQuestionAnswer",
                table: "OpenQuestionAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleGridAnswer",
                table: "MultipleGridAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceAnswer",
                table: "MultipleChoiceAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinearScaleAnswer",
                table: "LinearScaleAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinearScaleAnswer_LinearScales_QuestionId",
                table: "LinearScaleAnswer",
                column: "QuestionId",
                principalTable: "LinearScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceAnswer_MultipleChoices_QuestionId",
                table: "MultipleChoiceAnswer",
                column: "QuestionId",
                principalTable: "MultipleChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleGridAnswer_MultipleGrids_QuestionId",
                table: "MultipleGridAnswer",
                column: "QuestionId",
                principalTable: "MultipleGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenQuestionAnswer_OpenQuestions_QuestionId",
                table: "OpenQuestionAnswer",
                column: "QuestionId",
                principalTable: "OpenQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleChoiceAnswer_SingleChoices_QuestionId",
                table: "SingleChoiceAnswer",
                column: "QuestionId",
                principalTable: "SingleChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleGridAnswer_SingleGrids_QuestionId",
                table: "SingleGridAnswer",
                column: "QuestionId",
                principalTable: "SingleGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

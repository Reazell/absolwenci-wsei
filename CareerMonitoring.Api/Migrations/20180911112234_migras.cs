using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswersOptions",
                table: "SingleChoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswersOptions",
                table: "MultipleChoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MultipleGrids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Rows = table.Column<string>(nullable: true),
                    Cols = table.Column<string>(nullable: true),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleGrids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleGrids_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleGrids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Rows = table.Column<string>(nullable: true),
                    Cols = table.Column<string>(nullable: true),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleGrids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleGrids_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowTitle = table.Column<string>(nullable: true),
                    ColTitle = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    LinearScaleId = table.Column<int>(nullable: true),
                    MultipleChoiceId = table.Column<int>(nullable: true),
                    MultipleGridId = table.Column<int>(nullable: true),
                    OpenQuestionId = table.Column<int>(nullable: true),
                    SingleChoiceId = table.Column<int>(nullable: true),
                    SingleGridId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_LinearScales_LinearScaleId",
                        column: x => x.LinearScaleId,
                        principalTable: "LinearScales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_MultipleChoices_MultipleChoiceId",
                        column: x => x.MultipleChoiceId,
                        principalTable: "MultipleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_MultipleGrids_MultipleGridId",
                        column: x => x.MultipleGridId,
                        principalTable: "MultipleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_OpenQuestions_OpenQuestionId",
                        column: x => x.OpenQuestionId,
                        principalTable: "OpenQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_SingleChoices_SingleChoiceId",
                        column: x => x.SingleChoiceId,
                        principalTable: "SingleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_SingleGrids_SingleGridId",
                        column: x => x.SingleGridId,
                        principalTable: "SingleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_LinearScaleId",
                table: "Answer",
                column: "LinearScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_MultipleChoiceId",
                table: "Answer",
                column: "MultipleChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_MultipleGridId",
                table: "Answer",
                column: "MultipleGridId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_OpenQuestionId",
                table: "Answer",
                column: "OpenQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SingleChoiceId",
                table: "Answer",
                column: "SingleChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_SingleGridId",
                table: "Answer",
                column: "SingleGridId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleGrids_SurveyId",
                table: "MultipleGrids",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleGrids_SurveyId",
                table: "SingleGrids",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "MultipleGrids");

            migrationBuilder.DropTable(
                name: "SingleGrids");

            migrationBuilder.DropColumn(
                name: "AnswersOptions",
                table: "SingleChoices");

            migrationBuilder.DropColumn(
                name: "AnswersOptions",
                table: "MultipleChoices");
        }
    }
}

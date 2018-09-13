using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.CreateTable(
                name: "LinearScaleAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    MarkedValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinearScaleAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinearScaleAnswer_LinearScales_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "LinearScales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    MarkedAnswers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswer_MultipleChoices_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "MultipleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleGridAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    RowTitle = table.Column<string>(nullable: true),
                    ColTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleGridAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleGridAnswer_MultipleGrids_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "MultipleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenQuestionAnswer_OpenQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "OpenQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleChoiceAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    MarkedAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleChoiceAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleChoiceAnswer_SingleChoices_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SingleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleGridAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    RowTitle = table.Column<string>(nullable: true),
                    ColTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleGridAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleGridAnswer_SingleGrids_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SingleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinearScaleAnswer_QuestionId",
                table: "LinearScaleAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswer_QuestionId",
                table: "MultipleChoiceAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleGridAnswer_QuestionId",
                table: "MultipleGridAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenQuestionAnswer_QuestionId",
                table: "OpenQuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleChoiceAnswer_QuestionId",
                table: "SingleChoiceAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleGridAnswer_QuestionId",
                table: "SingleGridAnswer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinearScaleAnswer");

            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswer");

            migrationBuilder.DropTable(
                name: "MultipleGridAnswer");

            migrationBuilder.DropTable(
                name: "OpenQuestionAnswer");

            migrationBuilder.DropTable(
                name: "SingleChoiceAnswer");

            migrationBuilder.DropTable(
                name: "SingleGridAnswer");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColTitle = table.Column<string>(nullable: true),
                    MarkedAnswer = table.Column<string>(nullable: true),
                    MarkedAnswers = table.Column<string>(nullable: true),
                    MarkedCol = table.Column<string>(nullable: true),
                    MarkedCols = table.Column<string>(nullable: true),
                    MarkedValue = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    RowTitle = table.Column<string>(nullable: true),
                    Rows = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_LinearScales_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "LinearScales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_MultipleChoices_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "MultipleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_MultipleGrids_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "MultipleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_OpenQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "OpenQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_SingleChoices_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SingleChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_SingleGrids_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SingleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }
    }
}

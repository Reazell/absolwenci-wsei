using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class ngg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceScores");

            migrationBuilder.DropTable(
                name: "RowScores");

            migrationBuilder.DropTable(
                name: "FieldDataScores");

            migrationBuilder.DropTable(
                name: "QuestionScores");

            migrationBuilder.DropTable(
                name: "SurveyScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    QuestionPosition = table.Column<int>(nullable: false),
                    Select = table.Column<string>(nullable: true),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionScores_SurveyScores_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "SurveyScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldDataScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Input = table.Column<string>(nullable: true),
                    InputScore = table.Column<int>(nullable: false),
                    MaxLabel = table.Column<string>(nullable: true),
                    MaxValue = table.Column<int>(nullable: false),
                    MinLabel = table.Column<string>(nullable: true),
                    MinValue = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDataScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDataScores_QuestionScores_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuestionScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldDataId = table.Column<int>(nullable: false),
                    NumericalValue = table.Column<double>(nullable: false),
                    OptionPosition = table.Column<int>(nullable: false),
                    PercentageValue = table.Column<double>(nullable: false),
                    ViewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChoiceScores_FieldDataScores_FieldDataId",
                        column: x => x.FieldDataId,
                        principalTable: "FieldDataScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RowScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldDataId = table.Column<int>(nullable: false),
                    Input = table.Column<string>(nullable: true),
                    RowPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RowScores_FieldDataScores_FieldDataId",
                        column: x => x.FieldDataId,
                        principalTable: "FieldDataScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceScores_FieldDataId",
                table: "ChoiceScores",
                column: "FieldDataId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDataScores_QuestionId",
                table: "FieldDataScores",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionScores_SurveyId",
                table: "QuestionScores",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_RowScores_FieldDataId",
                table: "RowScores",
                column: "FieldDataId");
        }
    }
}

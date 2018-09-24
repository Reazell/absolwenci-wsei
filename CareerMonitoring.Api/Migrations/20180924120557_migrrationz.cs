using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class migrrationz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoiceOptionReports");

            migrationBuilder.DropTable(
                name: "RowChoiceOptionReports");

            migrationBuilder.DropTable(
                name: "RowReports");

            migrationBuilder.DropColumn(
                name: "SurveyAnswersNumber",
                table: "SurveyReports");

            migrationBuilder.DropColumn(
                name: "SurveyRecepientsNumber",
                table: "SurveyReports");

            migrationBuilder.DropColumn(
                name: "MaxLabel",
                table: "QuestionReports");

            migrationBuilder.DropColumn(
                name: "QuestionPosition",
                table: "QuestionReports");

            migrationBuilder.RenameColumn(
                name: "MinLabel",
                table: "QuestionReports",
                newName: "LabelsList");

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    ColoursList = table.Column<string>(nullable: true),
                    QuestionReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSets_QuestionReports_QuestionReportId",
                        column: x => x.QuestionReportId,
                        principalTable: "QuestionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_QuestionReportId",
                table: "DataSets",
                column: "QuestionReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.RenameColumn(
                name: "LabelsList",
                table: "QuestionReports",
                newName: "MinLabel");

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswersNumber",
                table: "SurveyReports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyRecepientsNumber",
                table: "SurveyReports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaxLabel",
                table: "QuestionReports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionPosition",
                table: "QuestionReports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChoiceOptionReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionCounter = table.Column<int>(nullable: false),
                    OptionPosition = table.Column<int>(nullable: false),
                    QuestionReportId = table.Column<int>(nullable: false),
                    Value = table.Column<bool>(nullable: false),
                    ViewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceOptionReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChoiceOptionReports_QuestionReports_QuestionReportId",
                        column: x => x.QuestionReportId,
                        principalTable: "QuestionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RowReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Input = table.Column<string>(nullable: true),
                    QuestionReportId = table.Column<int>(nullable: false),
                    RowPostion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RowReports_QuestionReports_QuestionReportId",
                        column: x => x.QuestionReportId,
                        principalTable: "QuestionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RowChoiceOptionReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionPosition = table.Column<int>(nullable: false),
                    RowReportId = table.Column<int>(nullable: false),
                    Value = table.Column<bool>(nullable: false),
                    ViewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowChoiceOptionReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RowChoiceOptionReports_RowReports_RowReportId",
                        column: x => x.RowReportId,
                        principalTable: "RowReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceOptionReports_QuestionReportId",
                table: "ChoiceOptionReports",
                column: "QuestionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RowChoiceOptionReports_RowReportId",
                table: "RowChoiceOptionReports",
                column: "RowReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RowReports_QuestionReportId",
                table: "RowReports",
                column: "QuestionReportId");
        }
    }
}

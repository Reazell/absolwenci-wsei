using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerMonitoring.Api.Migrations
{
    public partial class ProfileEdition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Accounts_GraduateId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Accounts_StudentId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Accounts_GraduateId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Accounts_StudentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Accounts_GraduateId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Accounts_StudentId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Accounts_GraduateId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Accounts_StudentId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Accounts_EmployerId",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_Accounts_GraduateId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_Accounts_StudentId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Accounts_GraduateId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Accounts_StudentId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_GraduateId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Language_GraduateId",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_Experience_GraduateId",
                table: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_Experience_StudentId",
                table: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_GraduateId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_StudentId",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_GraduateId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_StudentId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_GraduateId",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_StudentId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ProfileLink",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Student_ProfileLink",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "GraduateId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Certificate");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "JobOffer",
                newName: "JobOffers");

            migrationBuilder.RenameTable(
                name: "Experience",
                newName: "Experiences");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certificates");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Skills",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_StudentId",
                table: "Skills",
                newName: "IX_Skills_AccountId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Languages",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Language_StudentId",
                table: "Languages",
                newName: "IX_Languages_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffer_EmployerId",
                table: "JobOffers",
                newName: "IX_JobOffers_EmployerId");

            migrationBuilder.RenameColumn(
                name: "Graduate",
                table: "Educations",
                newName: "Graduated");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "SingleChoices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "MultipleChoices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "LinearScales",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentJob",
                table: "Experiences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Educations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameOfUniversity",
                table: "Educations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Certificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOffers",
                table: "JobOffers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MultipleGrids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
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
                name: "OpenQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileLinks_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
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
                    MultipleGridId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_MultipleGrids_MultipleGridId",
                        column: x => x.MultipleGridId,
                        principalTable: "MultipleGrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_AccountId",
                table: "Experiences",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AccountId",
                table: "Educations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AccountId",
                table: "Courses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_AccountId",
                table: "Certificates",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_MultipleGridId",
                table: "Answer",
                column: "MultipleGridId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleGrids_SurveyId",
                table: "MultipleGrids",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenQuestions_SurveyId",
                table: "OpenQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLinks_AccountId",
                table: "ProfileLinks",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SingleGrids_SurveyId",
                table: "SingleGrids",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Accounts_AccountId",
                table: "Certificates",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Accounts_AccountId",
                table: "Courses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Accounts_AccountId",
                table: "Educations",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Accounts_AccountId",
                table: "Experiences",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Accounts_EmployerId",
                table: "JobOffers",
                column: "EmployerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Accounts_AccountId",
                table: "Languages",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Accounts_AccountId",
                table: "Skills",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Accounts_AccountId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Accounts_AccountId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Accounts_AccountId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Accounts_AccountId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Accounts_EmployerId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Accounts_AccountId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Accounts_AccountId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "OpenQuestions");

            migrationBuilder.DropTable(
                name: "ProfileLinks");

            migrationBuilder.DropTable(
                name: "SingleGrids");

            migrationBuilder.DropTable(
                name: "MultipleGrids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOffers",
                table: "JobOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_AccountId",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_AccountId",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AccountId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_AccountId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "IsCurrentJob",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "NameOfUniversity",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Certificates");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "JobOffers",
                newName: "JobOffer");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "Experience");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "Certificate");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Skill",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_AccountId",
                table: "Skill",
                newName: "IX_Skill_StudentId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Language",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_AccountId",
                table: "Language",
                newName: "IX_Language_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_EmployerId",
                table: "JobOffer",
                newName: "IX_JobOffer_EmployerId");

            migrationBuilder.RenameColumn(
                name: "Graduated",
                table: "Education",
                newName: "Graduate");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Surveys",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "SingleChoices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "MultipleChoices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "LinearScales",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ProfileLink",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_ProfileLink",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Language",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Education",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Education",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduateId",
                table: "Certificate",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Certificate",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_GraduateId",
                table: "Skill",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_GraduateId",
                table: "Language",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_GraduateId",
                table: "Experience",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_StudentId",
                table: "Experience",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_GraduateId",
                table: "Education",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_StudentId",
                table: "Education",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_GraduateId",
                table: "Course",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudentId",
                table: "Course",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_GraduateId",
                table: "Certificate",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_StudentId",
                table: "Certificate",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Accounts_GraduateId",
                table: "Certificate",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Accounts_StudentId",
                table: "Certificate",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Accounts_GraduateId",
                table: "Course",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Accounts_StudentId",
                table: "Course",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Accounts_GraduateId",
                table: "Education",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Accounts_StudentId",
                table: "Education",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Accounts_GraduateId",
                table: "Experience",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Accounts_StudentId",
                table: "Experience",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Accounts_EmployerId",
                table: "JobOffer",
                column: "EmployerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Accounts_GraduateId",
                table: "Language",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Accounts_StudentId",
                table: "Language",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Accounts_GraduateId",
                table: "Skill",
                column: "GraduateId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Accounts_StudentId",
                table: "Skill",
                column: "StudentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

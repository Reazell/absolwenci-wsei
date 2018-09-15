using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.Surveys.Answers;
using CareerMonitoring.Core.Domains.Surveys.Answers.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Data {
    public class CareerMonitoringContext : DbContext {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FieldData> FieldData { get; set; }
        public DbSet<ChoiceOption> ChoiceOptions { get; set; }
        public DbSet<Row> Rows { get; set; }
        // public DbSet<LinearScale> LinearScales { get; set; }
        // public DbSet<MultipleChoice> MultipleChoices { get; set; }
        // public DbSet<SingleChoice> SingleChoices { get; set; }
        // public DbSet<OpenQuestion> OpenQuestions { get; set; }
        // public DbSet<SingleGrid> SingleGrids { get; set; }
        // public DbSet<MultipleGrid> MultipleGrids { get; set; }
        // public DbSet<Answer> Answers { get; set; }
        // public DbSet<LinearScaleAnswer> LinearScalesAnswers { get; set; }
        // public DbSet<MultipleChoiceAnswer> MultipleChoicesAnswers { get; set; }
        // public DbSet<SingleChoiceAnswer> SingleChoicesAnswers { get; set; }
        // public DbSet<OpenQuestionAnswer> OpenQuestionsAnswers { get; set; }
        // public DbSet<SingleGridAnswer> SingleGridsAnswers { get; set; }
        // public DbSet<MultipleGridAnswer> MultipleGridsAnswers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<CareerOffice> CareerOffices { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<AccountRestoringPassword> AccountRestoringPasswords { get; set; }

        public CareerMonitoringContext (DbContextOptions<CareerMonitoringContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account> ()
                .HasOne (a => a.AccountActivation)
                .WithOne (b => b.Account)
                .HasForeignKey<AccountActivation> (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasOne (a => a.AccountRestoringPassword)
                .WithOne (b => b.Account)
                .HasForeignKey<AccountRestoringPassword> (b => b.AccountId);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.Questions)
                .WithOne (b => b.Survey)
                .HasForeignKey (s => s.SurveyId);
            modelBuilder.Entity<Question> ()
                .HasMany (a => a.FieldData)
                .WithOne (b => b.Question)
                .HasForeignKey (s => s.QuestionId);
            modelBuilder.Entity<FieldData> ()
                .HasMany (a => a.Rows)
                .WithOne (b => b.FieldData)
                .HasForeignKey (s => s.FieldDataId);
            modelBuilder.Entity<FieldData> ()
                .HasMany (a => a.ChoiceOptions)
                .WithOne (b => b.FieldData)
                .HasForeignKey (s => s.FieldDataId);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.LinearScales)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.SingleChoices)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.MultipleChoices)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.OpenQuestions)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.SingleGrids)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<Survey> ()
            //     .HasMany (a => a.MultipleGrids)
            //     .WithOne (s => s.Survey)
            //     .HasForeignKey (b => b.SurveyId)
            //     .OnDelete (DeleteBehavior.Cascade);
            // modelBuilder.Entity<LinearScale> ()
            //     .HasMany (a => a.LinearScaleAnswers)
            //     .WithOne (s => s.LinearScale)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
            // modelBuilder.Entity<MultipleChoice> ()
            //     .HasMany (a => a.MultipleChoiceAnswers)
            //     .WithOne (s => s.MultipleChoice)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
            // modelBuilder.Entity<MultipleGrid> ()
            //     .HasMany (a => a.MultipleGridAnswers)
            //     .WithOne (s => s.MultipleGrid)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
            // modelBuilder.Entity<OpenQuestion> ()
            //     .HasMany (a => a.OpenQuestionAnswers)
            //     .WithOne (s => s.OpenQuestion)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
            // modelBuilder.Entity<SingleChoice> ()
            //     .HasMany (a => a.SingleChoiceAnswers)
            //     .WithOne (s => s.SingleChoice)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
            // modelBuilder.Entity<SingleGrid> ()
            //     .HasMany (a => a.SingleGridAnswers)
            //     .WithOne (s => s.SingleGrid)
            //     .HasForeignKey (b => b.QuestionId)
            //     .OnDelete (DeleteBehavior.Restrict);
        }
    }
}
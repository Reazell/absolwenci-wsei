using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.ImportFile;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using CareerMonitoring.Core.Domains.SurveyTemplates;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Data {
    public class CareerMonitoringContext : DbContext {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FieldData> FieldData { get; set; }
        public DbSet<ChoiceOption> ChoiceOptions { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<SurveyUserIdentifier> SurveyUserIdentifiers { get; set; }
        public DbSet<SurveyTemplate> SurveyTemplates { get; set; }
        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }
        public DbSet<FieldDataTemplate> FieldDataTemplates { get; set; }
        public DbSet<ChoiceOptionTemplate> ChoiceOptionTemplates { get; set; }
        public DbSet<RowTemplate> RowTemplates { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<QuestionAnswer> QuestionsAnswers { get; set; }
        public DbSet<FieldDataAnswer> FieldDataAnswers { get; set; }
        public DbSet<ChoiceOptionAnswer> ChoiceOptionsAnswers { get; set; }
        public DbSet<RowChoiceOptionAnswer> RowChoiceOptionsAnswers { get; set; }
        public DbSet<RowAnswer> RowAnswers { get; set; }
        public DbSet<SurveyReport> SurveyReports { get; set; }
        public DbSet<QuestionReport> QuestionReports { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CareerOffice> CareerOffices { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<AccountRestoringPassword> AccountRestoringPasswords { get; set; }
        public DbSet<UnregisteredUser> UnregisteredUsers { get; set; }

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
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Question> ()
                .HasMany (a => a.FieldData)
                .WithOne (b => b.Question)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<FieldData> ()
                .HasMany (a => a.Rows)
                .WithOne (b => b.FieldData)
                .HasForeignKey (s => s.FieldDataId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<FieldData> ()
                .HasMany (a => a.ChoiceOptions)
                .WithOne (b => b.FieldData)
                .HasForeignKey (s => s.FieldDataId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<SurveyTemplate> ()
                .HasMany (a => a.QuestionTemplates)
                .WithOne (b => b.SurveyTemplate)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<QuestionTemplate> ()
                .HasMany (a => a.FieldDataTemplates)
                .WithOne (b => b.QuestionTemplate)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<FieldDataTemplate> ()
                .HasMany (a => a.RowTemplates)
                .WithOne (b => b.FieldDataTemplate)
                .HasForeignKey (s => s.FieldDataTemplateId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<FieldDataTemplate> ()
                .HasMany (a => a.ChoiceOptionTemplates)
                .WithOne (b => b.FieldDataTemplate)
                .HasForeignKey (s => s.FieldDataTemplateId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<SurveyAnswer> ()
                .HasMany (a => a.QuestionsAnswers)
                .WithOne (b => b.SurveyAnswer);
            modelBuilder.Entity<QuestionAnswer> ()
                .HasMany (a => a.FieldDataAnswers)
                .WithOne (b => b.QuestionAnswer);
            modelBuilder.Entity<FieldDataAnswer> ()
                .HasMany (a => a.RowsAnswers)
                .WithOne (b => b.FieldDataAnswer)
                .HasForeignKey (s => s.FieldDataAnswerId);
            modelBuilder.Entity<FieldDataAnswer> ()
                .HasMany (a => a.ChoiceOptionAnswers)
                .WithOne (b => b.FieldDataAnswer)
                .HasForeignKey (s => s.FieldDataAnswerId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<RowAnswer> ()
                .HasMany (a => a.RowChoiceOptionAnswers)
                .WithOne (b => b.RowAnswer)
                .HasForeignKey (s => s.RowAnswerId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<SurveyReport> ()
                .HasMany (a => a.QuestionsReports)
                .WithOne (b => b.SurveyReport)
                .HasForeignKey (s => s.SurveyReportId);
            modelBuilder.Entity<QuestionReport> ()
                .HasMany (a => a.DataSets)
                .WithOne (b => b.QuestionReport)
                .HasForeignKey (s => s.QuestionReportId);
        }
    }
}
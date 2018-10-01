using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.SurveyReport;
using CareerMonitoring.Core.Domains.Surveys;
using CareerMonitoring.Core.Domains.SurveysAnswers;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Data {
    public class CareerMonitoringContext : DbContext {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FieldData> FieldData { get; set; }
        public DbSet<ChoiceOption> ChoiceOptions { get; set; }
        public DbSet<Row> Rows { get; set; }
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
        public DbSet<Student> Students { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<CareerOffice> CareerOffices { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<AccountRestoringPassword> AccountRestoringPasswords { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProfileLink> ProfileLinks { get; set; }
        public DbSet<Skill> Skills { get; set; }
        

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
            modelBuilder.Entity<Account> ()
                .HasMany (a => a.Certificates)
                .WithOne (s => s.Account)
                .HasForeignKey (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasMany (a => a.Courses)
                .WithOne (s => s.Account)
                .HasForeignKey (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasMany (a => a.Educations)
                .WithOne (s => s.Account)
                .HasForeignKey (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasMany (a => a.Experiences)
                .WithOne (s => s.Account)
                .HasForeignKey (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasMany (a => a.Languages)
                .WithOne (s => s.Account)
                .HasForeignKey (b => b.AccountId);
            modelBuilder.Entity<Account> ()
                .HasOne (a => a.ProfileLink)
                .WithOne (s => s.Account)
                .HasForeignKey<ProfileLink> (b => b.AccountId);
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
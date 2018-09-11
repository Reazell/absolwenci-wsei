using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using CareerMonitoring.Core.Domains.Surveys;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Data {
    public class CareerMonitoringContext : DbContext {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<LinearScale> LinearScales { get; set; }
        public DbSet<MultipleChoice> MultipleChoices { get; set; }
        public DbSet<SingleChoice> SingleChoices { get; set; }
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<SingleGrid> SingleGrids { get; set; }
        public DbSet<MultipleGrid> MultipleGrids { get; set; }
        public DbSet<Answer> Answers { get; set; }
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
                .HasMany (a => a.LinearScales)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.SingleChoices)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.MultipleChoices)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.OpenQuestions)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.SingleGrids)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<Survey> ()
                .HasMany (a => a.MultipleGrids)
                .WithOne (s => s.Survey)
                .HasForeignKey (b => b.SurveyId)
                .OnDelete (DeleteBehavior.Cascade);
            modelBuilder.Entity<LinearScale> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.LinearScale)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<SingleChoice> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.SingleChoice)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<MultipleChoice> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.MultipleChoice)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<OpenQuestion> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.OpenQuestion)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<SingleGrid> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.SingleGrid)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
            modelBuilder.Entity<MultipleGrid> ()
                .HasMany (a => a.Answers)
                .WithOne (l => l.MultipleGrid)
                .HasForeignKey (b => b.QuestionId)
                .OnDelete (DeleteBehavior.Restrict);
        }
    }
}
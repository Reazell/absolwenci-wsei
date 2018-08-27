using CareerMonitoring.Core.Domains;
using CareerMonitoring.Core.Domains.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CareerMonitoring.Infrastructure.Data {
    public class CareerMonitoringContext : DbContext {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<CareerOffice> CareerOffices { get; set; }
        public DbSet<Employer> Employers { get; set; }

        public CareerMonitoringContext (DbContextOptions<CareerMonitoringContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) { }
    }
}
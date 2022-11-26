using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverLicence> DriverLicences { get; set; } = null!;
        public DbSet<Supervisor> Supervisors { get; set; } = null!;
        public DbSet<DriverLicenceCategory> DriverLicenceCategories { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Violation> Violations { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=gibdd;Username=postgres;Password=password"
                );
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }
    }
}

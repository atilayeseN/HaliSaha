using Microsoft.EntityFrameworkCore;
using HaliSaha.Models;

namespace HaliSaha.DataAccess
{
    public class PostgreSqlContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Patient> patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}

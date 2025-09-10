using Finance_Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance_Api.Infrastructure.Data
{
    public class FinanceTrackerDbContext : DbContext
    {
        public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.Property(x => x.Name).HasMaxLength(200);
                e.Property(x => x.Email).HasMaxLength(320);
            });
        }

        // DbSets
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
    }
}

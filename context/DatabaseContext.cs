using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Models;


namespace SwimmingAppBackend.context
{
    public class SwimmingAppDBContext : DbContext
    {
        public SwimmingAppDBContext(DbContextOptions<SwimmingAppDBContext> options) : base(options) { }

        public DbSet<Swim> Swims { get; set; }

        public DbSet<Split> Splits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the one-to-many relationship between Swim and Split
            modelBuilder.Entity<Swim>()
                .HasMany(s => s.Splits)
                .WithOne(sp => sp.Swim)
                .HasForeignKey(sp => sp.SwimId);
        }
    }
}
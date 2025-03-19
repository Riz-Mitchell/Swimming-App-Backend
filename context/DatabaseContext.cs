using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Models;


namespace SwimmingAppBackend.Context
{
    public class SwimmingAppDBContext : DbContext
    {
        public SwimmingAppDBContext(DbContextOptions<SwimmingAppDBContext> options) : base(options) { }

        public DbSet<User> users;
        public DbSet<SwimmerProfile> swimmerProfiles;
        public DbSet<Swim> swims;
        public DbSet<Split> splits;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SwimmerProfile>()
                .HasOne(swimmerProfile => swimmerProfile.user)
                .WithOne(user => user.swimmerProfile)
                .HasForeignKey(swimmerProfile => swimmerProfile.userId);

            modelBuilder.Entity<Swim>()
                .HasOne(swim => swim.swimmerProfile)
                .WithMany(swimmerProfile => swimmerProfile.swims)
                .HasForeignKey(swim => swim.swimmerProfileId);

            modelBuilder.Entity<Split>()
                .HasOne(split => split.swim)
                .WithMany(swim => swim.splits)
                .HasForeignKey(split => split.swimId);
        }
    }
}
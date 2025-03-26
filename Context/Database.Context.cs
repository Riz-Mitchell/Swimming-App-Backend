using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Models;


namespace SwimmingAppBackend.Context
{
    public class SwimmingAppDBContext : DbContext
    {
        public SwimmingAppDBContext(DbContextOptions<SwimmingAppDBContext> options) : base(options) { }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Squad> Squads { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SwimmerData> SwimmerDatas { get; set; }

        public DbSet<CoachData> CoachDatas { get; set; }

        public DbSet<Swim> Swims { get; set; }

        public DbSet<Split> Splits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Squad>()
            //     .HasOne(squad => squad.club)
            //     .WithMany(club => club.squads)
            //     .HasForeignKey(squad => squad.clubId);

            modelBuilder.Entity<Squad>()
                .HasOne(Squad => Squad.Club)
                .WithMany(Club => Club.Squads)
                .HasForeignKey(Squad => Squad.ClubId);

            modelBuilder.Entity<User>()
                .HasOne(User => User.Squad)
                .WithMany(Squad => Squad.Members)
                .HasForeignKey(User => User.SquadId);

            modelBuilder.Entity<SwimmerData>()
                .HasOne(SwimmerData => SwimmerData.UserOwner)
                .WithOne(User => User.SwimmerData)
                .HasForeignKey<SwimmerData>(SwimmerData => SwimmerData.UserOwnerId);


            modelBuilder.Entity<CoachData>()
                .HasOne(CoachData => CoachData.UserOwner)
                .WithOne(User => User.CoachData)
                .HasForeignKey<CoachData>(CoachData => CoachData.UserOwnerId);

            modelBuilder.Entity<Swim>()
                .HasOne(Swim => Swim.SwimmerData)
                .WithMany(SwimmerData => SwimmerData.Swims)
                .HasForeignKey(Swim => Swim.SwimmerDataId);

            modelBuilder.Entity<Split>()
                .HasOne(Split => Split.Swim)
                .WithMany(Swim => Swim.Splits)
                .HasForeignKey(Split => Split.SwimId);
        }
    }
}
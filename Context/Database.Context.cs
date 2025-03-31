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

        public DbSet<SwimmerMetaData> SwimmerMetaDatas { get; set; }

        public DbSet<CoachMetaData> CoachMetaDatas { get; set; }

        public DbSet<Swim> Swims { get; set; }

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

            modelBuilder.Entity<SwimmerMetaData>()
                .HasOne(SwimmerMetaData => SwimmerMetaData.UserOwner)
                .WithOne(User => User.SwimmerMetaData)
                .HasForeignKey<SwimmerMetaData>(SwimmerMetaData => SwimmerMetaData.UserOwnerId);


            modelBuilder.Entity<CoachMetaData>()
                .HasOne(CoachMetaData => CoachMetaData.UserOwner)
                .WithOne(User => User.CoachMetaData)
                .HasForeignKey<CoachMetaData>(CoachMetaData => CoachMetaData.UserOwnerId);

            modelBuilder.Entity<Swim>()
                .HasOne(Swim => Swim.SwimmerMetaData)
                .WithMany(SwimmerMetaData => SwimmerMetaData.Swims)
                .HasForeignKey(Swim => Swim.SwimmerMetaDataId);

        }
    }
}
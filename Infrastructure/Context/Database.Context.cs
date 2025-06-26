using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwimmingAppBackend.Domain.Helpers;
using SwimmingAppBackend.Enum;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Infrastructure.Seeders;


namespace SwimmingAppBackend.Infrastructure.Context
{
    public class SwimmingAppDBContext : DbContext
    {
        public SwimmingAppDBContext(DbContextOptions<SwimmingAppDBContext> options) : base(options) { }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<UserAchievement> UserAchievements { get; set; }

        public DbSet<AthleteData> AthleteDatas { get; set; }

        public DbSet<CoachData> CoachDatas { get; set; }

        public DbSet<Swim> Swims { get; set; }

        public DbSet<Split> Splits { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<TimeSheet> TimeSheets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var splitsConverter = new ValueConverter<List<SplitData>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<SplitData>>(v, (JsonSerializerOptions)null));

            modelBuilder.Entity<TimeSheet>()
                .Property(ts => ts.SplitDataForTimes)
                .HasConversion(splitsConverter);

            modelBuilder.Entity<Achievement>()
                .HasData(AchievementSeeder.GetPredifinedAchievements());

            modelBuilder.Entity<Achievement>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<UserAchievement>()
                .HasIndex(ua => new { ua.UserId, ua.AchievementId })
                .IsUnique();

            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);      // Dependency

            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievements)
                .HasForeignKey(ua => ua.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);      // Dependency

            modelBuilder.Entity<AthleteData>()
                .HasOne(ad => ad.UserOwner)
                .WithOne(uo => uo.AthleteData)
                .HasForeignKey<AthleteData>(ad => ad.UserOwnerId)
                .OnDelete(DeleteBehavior.Cascade);      // Dependency

            modelBuilder.Entity<CoachData>()
                .HasOne(cd => cd.UserOwner)
                .WithOne(uo => uo.CoachData)
                .HasForeignKey<CoachData>(cd => cd.UserOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Swim>()
                .HasOne(s => s.AthleteDataOwner)
                .WithMany(ado => ado.Swims)
                .HasForeignKey(s => s.AthleteDataOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Split>()
                .HasOne(s => s.Swim)
                .WithMany(sw => sw.Splits)
                .HasForeignKey(s => s.SwimId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AthleteData)
                .WithOne(ad => ad.UserOwner)
                .HasForeignKey<User>(u => u.AthleteDataId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CoachData)
                .WithOne(ad => ad.UserOwner)
                .HasForeignKey<User>(u => u.CoachDataId);

        }
    }
}
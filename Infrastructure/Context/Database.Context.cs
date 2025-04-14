using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend.Infrastructure.Models;


namespace SwimmingAppBackend.Infrastructure.Context
{
    public class SwimmingAppDBContext : DbContext
    {
        public SwimmingAppDBContext(DbContextOptions<SwimmingAppDBContext> options) : base(options) { }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<AthleteData> AthleteDatas { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<CoachData> CoachDatas { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Set> Sets { get; set; }

        public DbSet<SetItem> SetItems { get; set; }

        public DbSet<Squad> Squads { get; set; }

        public DbSet<Swim> Swims { get; set; }

        public DbSet<TimeTable> TimeTables { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<GoalSwim> GoalSwims { get; set; }

        public DbSet<TimeSheet> TimeSheets { get; set; }

        public DbSet<TimeSheetItem> TimeSheetsItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AthleteData>()
                .HasOne(ad => ad.UserOwner)
                .WithOne(uo => uo.AthleteData)
                .HasForeignKey<AthleteData>(ad => ad.UserOwnerId)
                .OnDelete(DeleteBehavior.Cascade);      // Dependency

            modelBuilder.Entity<Award>()
                .HasOne(a => a.CoachDataOwner)
                .WithMany(cdo => cdo.Awards)
                .HasForeignKey(a => a.CoachDataOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoachData>()
                .HasOne(cd => cd.UserOwner)
                .WithOne(uo => uo.CoachData)
                .HasForeignKey<CoachData>(cd => cd.UserOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.TimeTable)
                .WithMany(tt => tt.Sessions)
                .HasForeignKey(s => s.TimeTableId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.CoachDataOwner)
                .WithMany(cdo => cdo.Sessions)
                .HasForeignKey(s => s.CoachDataOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Set>()
                .HasOne(s => s.Session)
                .WithMany(sesh => sesh.Sets)
                .HasForeignKey(s => s.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetItem>()
                .HasOne(si => si.Set)
                .WithMany(s => s.SetItems)
                .HasForeignKey(si => si.SetId)
                .OnDelete(DeleteBehavior.Cascade);


            // Squad can exist without a club
            modelBuilder.Entity<Squad>()
                .HasOne(s => s.Club)
                .WithMany(c => c.Squads)
                .HasForeignKey(s => s.ClubId);

            modelBuilder.Entity<Swim>()
                .HasOne(s => s.AthleteDataOwner)
                .WithMany(ado => ado.Swims)
                .HasForeignKey(s => s.AthleteDataOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TimeTable>()
                .HasOne(tt => tt.Squad)
                .WithMany(s => s.TimeTables)
                .HasForeignKey(tt => tt.SquadId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Squad)
                .WithMany(s => s.Members)
                .HasForeignKey(u => u.SquadId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AthleteData)
                .WithOne(ad => ad.UserOwner)
                .HasForeignKey<User>(u => u.AthleteDataId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CoachData)
                .WithOne(ad => ad.UserOwner)
                .HasForeignKey<User>(u => u.AthleteDataId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.TimeSheet)
                .WithOne(ts => ts.Event)
                .HasForeignKey<Event>(e => e.TimeSheetId);

            modelBuilder.Entity<TimeSheetItem>()
                .HasOne(tsi => tsi.TimeSheet)
                .WithMany(ts => ts.TimeSheetItems)
                .HasForeignKey(tsi => tsi.TimeSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Swim>()
                .HasOne(s => s.Event)
                .WithMany()
                .HasForeignKey(s => s.EventId);

            modelBuilder.Entity<GoalSwim>()
                .HasOne(gs => gs.AthleteDataOwner)
                .WithMany(ado => ado.GoalSwims)
                .HasForeignKey(gs => gs.AthleteDataOwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
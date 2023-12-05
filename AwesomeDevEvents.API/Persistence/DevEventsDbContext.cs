using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {
        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventSpeakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);

                e.Property(de => de.Title)
                    .IsRequired(false)
                    .HasMaxLength(150)
                    .HasColumnType("varchar(150)");

                e.Property(de => de.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                e.Property(de => de.StartDate)
                    .HasColumnName("Start_Date");

                e.Property(de => de.EndDate)
                    .HasColumnName("End_Date");

                e.HasMany(de => de.Speakers)
                    .WithOne()
                    .HasForeignKey(de => de.DevEventId);
            });

            modelBuilder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(de => de.Name)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(de => de.TalkTitle)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(de => de.TalkDescription)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
                e.Property(de => de.LinkedInProfile)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

            });
        }

    }
}

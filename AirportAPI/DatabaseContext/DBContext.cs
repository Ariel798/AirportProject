using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
namespace DatabaseContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<FlightLog>? FlightLog { get; set; }
        public DbSet<LegEntity>? Log { get; set; }
        public DbSet<FlightStationLog>? FlightStationLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FlightLog>().HasData(
                new FlightLog { FlightId = 1, FlightName = "IZ233", PassangersCount = 60, LandingTime = DateTime.UtcNow.ToShortDateString(),DepartureTime = DateTime.Now.ToShortDateString() } 
                );            
            modelBuilder.Entity<FlightStationLog>().HasData(
                new FlightStationLog {  Id = 1,PlaneId = 1, CreationTime = DateTime.Now, LegId = 1} 
                );
            modelBuilder.Entity<LegEntity>().HasData(
                new LegEntity { LegNumber = 1, LegTarget = "Runaway" },
                new LegEntity { LegNumber = 2, LegTarget = "Runaway"  },
                new LegEntity { LegNumber = 3, LegTarget = "Runaway" },
                new LegEntity { LegNumber = 4, LegTarget = "Runaway" },
                new LegEntity { LegNumber = 5, LegTarget = "Transportation"},
                new LegEntity { LegNumber = 6, LegTarget = "Load/Unload" },
                new LegEntity { LegNumber = 7, LegTarget = "Load/Unload"},
                new LegEntity { LegNumber = 8, LegTarget = "Transportation" }
                );

        }
    }
}
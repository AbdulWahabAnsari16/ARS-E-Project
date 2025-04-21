using Microsoft.EntityFrameworkCore;

namespace ARS.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<CancellationPolicie> CancellationPolicies { get; set; } // Fixed typo
        public DbSet<City> Cities { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightRoutes> FlightRoutes { get; set; }

        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<ItinerarySegment> ItinerarySegments { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PricingRule> PricingRules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<MileageHistory> MileageHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the FlightRoutes relationships
            modelBuilder.Entity<FlightRoutes>()
                .HasOne(fr => fr.OriginAirport)   // Navigation property in FlightRoutes
                .WithMany(a => a.OriginRoutes)   // Collection in Airport
                .HasForeignKey(fr => fr.OriginAirportID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<FlightRoutes>()
                .HasOne(fr => fr.DestinationAirport) // Navigation property in FlightRoutes
                .WithMany(a => a.DestinationRoutes)  // Collection in Airport
                .HasForeignKey(fr => fr.DestinationAirportID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

    }

}
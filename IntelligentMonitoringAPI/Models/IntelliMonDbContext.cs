namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IntelliMonDbContext : DbContext
    {
        public IntelliMonDbContext()
            : base("name=IntelliMonDbContext")
        {
        }
        
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DeviceNetwork> DeviceNetworks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<LocationResource> LocationResources { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SensorMeasurement> SensorMeasurements { get; set; }
        public DbSet<DataCollector> DataCollectors { get; set; }
        public DbSet<DeviceHistory> DeviceHistories { get; set; }
        public DbSet<DailyStatistic> DailyStatistics { get; set; }
        public DbSet<MonthlyStatistic> MonthlyStatistics { get; set; }
        public DbSet<WeeklyStatistic> WeeklyStatistics { get; set; }
        public DbSet<YearlyStatistic> YearlyStatistics { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }

        public DbSet<AccumulatedStatistic> AccumulatedStatistics { get; set; }
        public DbSet<CustomEvent> CustomEvents { get; set; }
        public DbSet<FailurePronedDevice> FailurePronedDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public static IntelliMonDbContext Create()
        {
            return new IntelliMonDbContext();
        }
    }
}

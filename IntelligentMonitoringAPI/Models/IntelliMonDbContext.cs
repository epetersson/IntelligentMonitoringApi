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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DeviceNetwork> DeviceNetworks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public static IntelliMonDbContext Create()
        {
            return new IntelliMonDbContext();
        }
    }
}

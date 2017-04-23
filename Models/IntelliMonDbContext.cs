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
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceNetwork> DeviceNetworks { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationResource> LocationResources { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<SensorMeasurement> SensorMeasurements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .Property(e => e.ExternalId)
                .IsUnicode(false);

            modelBuilder.Entity<Device>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Device>()
                .Property(e => e.LocationName)
                .IsUnicode(false);

            modelBuilder.Entity<Device>()
                .Property(e => e.ContactLost)
                .IsFixedLength();

            modelBuilder.Entity<Device>()
                .HasMany(e => e.Histories)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.Device_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasMany(e => e.Sensors)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.Device_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeviceNetwork>()
                .Property(e => e.External_id)
                .IsUnicode(false);

            modelBuilder.Entity<DeviceNetwork>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DeviceNetwork>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.DeviceNetwork)
                .HasForeignKey(e => e.DeviceNetwork_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<History>()
                .Property(e => e.External_Id)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.External_Id)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.ParentLocation_Name)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Devices)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.Location_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Location1)
                .WithOptional(e => e.Location2)
                .HasForeignKey(e => e.ParentLocation_Id);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.LocationResources)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.Location_Id);

            modelBuilder.Entity<LocationResource>()
                .Property(e => e.External_Id)
                .IsUnicode(false);

            modelBuilder.Entity<LocationResource>()
                .Property(e => e.URI)
                .IsUnicode(false);

            modelBuilder.Entity<LocationResource>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<LocationResource>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<LocationResource>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<LocationResource>()
                .HasMany(e => e.Positions)
                .WithRequired(e => e.LocationResource)
                .HasForeignKey(e => e.LocationResource_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.External_Id)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.EType)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.External_Id)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.SensorMeasurements)
                .WithOptional(e => e.Sensor)
                .HasForeignKey(e => e.Sensor_Id);
        }
        public static IntelliMonDbContext Create()
        {
            return new IntelliMonDbContext();
        }
    }
}

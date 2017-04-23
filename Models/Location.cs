namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Devices = new HashSet<Device>();
            Location1 = new HashSet<Location>();
            LocationResources = new HashSet<LocationResource>();
        }

        public int Id { get; set; }

        [Column("External-Id")]
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        [Column("DeviceNetwork-Id")]
        public int DeviceNetwork_Id { get; set; }

        [Column("Position-Id")]
        public int? Position_Id { get; set; }

        [Column("ParentLocation-Id")]
        public int? ParentLocation_Id { get; set; }

        [Column("ParentLocation-Name")]
        [StringLength(50)]
        public string ParentLocation_Name { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }

        public virtual DeviceNetwork DeviceNetwork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Location1 { get; set; }

        public virtual Location Location2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationResource> LocationResources { get; set; }
    }
}

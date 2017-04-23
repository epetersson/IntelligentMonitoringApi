using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeviceNetwork")]
    public partial class DeviceNetwork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeviceNetwork()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }

        [Column("External-id")]
        [Required]
        [StringLength(50)]
        public string External_id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Location> Locations { get; set; }
    }
}

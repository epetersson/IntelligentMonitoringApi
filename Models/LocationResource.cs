namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationResource")]
    public partial class LocationResource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationResource()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }

        [Column("External-Id")]
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        [StringLength(200)]
        public string URI { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [Column("Location-Id")]
        public int? Location_Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Label { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Position> Positions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationDto
    {
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        public int DeviceNetwork_Id { get; set; }

        public int? Position_Id { get; set; }

        public int? ParentLocation_Id { get; set; }

        [StringLength(50)]
        public string ParentLocation_Name { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<DeviceDto> Devices { get; set; }

        public DeviceNetworkDto DeviceNetwork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Location> Location1 { get; set; }

        public Location Location2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<LocationResource> LocationResources { get; set; }
    }
}
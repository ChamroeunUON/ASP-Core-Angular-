using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Angular.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
        public Vehicle Vihicle { get; set; }
        public Feature  Feature { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Angular.Models
{
    [Table("VihicleFeatures")]
    public class VihicleFeature
    {
        public int VihicleId { get; set; }
        public int FeatureID { get; set; }
        public Vihicle Vihicle { get; set; }
        public Feature  Feature { get; set; }

    }
}
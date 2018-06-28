using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Angular.Models
{
    [Table("VihicleFeatures")]
    public class VihicleFeature
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public int VihicleId { get; set; }
        public int FeatureID { get; set; }
        public Vihicle Vihicle { get; set; }
=======
        public int VehicleId { get; set; }
=======
        public int VihicleId { get; set; }
>>>>>>> parent of fe27b27... Add API POST UPDATE DELETE
        public int FeatureId { get; set; }
        public Vehicle Vihicle { get; set; }
>>>>>>> 0ef9c1498861fd6d5a41dc4ddcab1f761fa941bb
        public Feature  Feature { get; set; }

    }
}
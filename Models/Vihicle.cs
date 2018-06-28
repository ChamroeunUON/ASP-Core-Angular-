using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Azure.KeyVault.Models;

namespace ASP_Angular.Models
{

<<<<<<< HEAD:Models/Vihicle.cs
    [Table ("Vihicles")]
    public class Vihicle {
=======
    [Table ("Vehicles")]
    public class Vehicle {
>>>>>>> 0ef9c1498861fd6d5a41dc4ddcab1f761fa941bb:Models/Vehicle.cs

        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }
         [Required]
        [StringLength (255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength (255)]

<<<<<<< HEAD:Models/Vihicle.cs
        public string Phone { get; set; }

        [StringLength (255)]
        public string Email { get; set; }
        public ICollection<VihicleFeature> Features { get; set; }
        public Vihicle () {
            Features = new Collection<VihicleFeature> ();
=======
        public string ContactPhone { get; set; }


        public ICollection<VehicleFeature> Features { get; set; }
        public Vehicle () {
            Features = new Collection<VehicleFeature> ();
>>>>>>> 0ef9c1498861fd6d5a41dc4ddcab1f761fa941bb:Models/Vehicle.cs
        }

    }
}
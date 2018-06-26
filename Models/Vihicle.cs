using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Angular.Models {

    [Table ("Vihicles")]
    public class Vihicle {

        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength (255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength (255)]

        public string Phone { get; set; }

        [StringLength (255)]
        public string Email { get; set; }
        public ICollection<VihicleFeature> Features { get; set; }
        public Vihicle () {
            Features = new Collection<VihicleFeature> ();
        }

    }
}
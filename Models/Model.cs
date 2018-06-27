using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Angular.Models
{
    [Table("Models")]
    public class Model
    {
        public int Id{set;get;}
        public string Name { get; set; } 
        public int MakeId { get; set; }
        public Make Make { get; set; }
        // public ICollection<Feature> Features { get; set; }
    }   
}
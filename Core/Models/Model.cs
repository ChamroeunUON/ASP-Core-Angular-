using System.Collections.Generic;

namespace ASP_Angular.Core.Models
{
    public class Model
    {
        public int Id{set;get;}
        public string Name { get; set; } 
        public int MakeId { get; set; }
        public Make Make { get; set; }
        // public ICollection<Feature> Features { get; set; }
        
    }   
}
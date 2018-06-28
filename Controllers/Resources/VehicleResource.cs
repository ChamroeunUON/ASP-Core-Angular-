using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASP_Angular.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public ModelResource Model { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }
         public ContactResource Contact { get; set; }
         public ICollection<int> Features { get; set; }
         public VehicleResource()
         {
             Features = new Collection<int>();
         }
    }
}
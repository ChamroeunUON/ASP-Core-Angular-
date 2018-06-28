using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASP_Angular.Controllers.Resources
{
    public class VehicleReource
    {
        public int Id { get; set; }
        public ModelResource Model { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }
         public ContactResource Contact { get; set; }
         public ICollection<FeatureResource> Feature { get; set; }
         public VehicleReource()
         {
             Feature = new Collection<FeatureResource>();
         }
    }
}
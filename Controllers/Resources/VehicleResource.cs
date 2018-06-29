using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASP_Angular.Models;

namespace ASP_Angular.Controllers.Resources {
    public class VehicleResource {
        public int Id { get; set; }
        public ModelResource Model { get; set; }
        public MakeResource Make { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }
        public ContactResource Contact { get; set; }

        public ICollection<FeatureResource> Features { get; set; }
        public VehicleResource () {
            Features = new Collection<FeatureResource> ();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASP_Angular.Models;

namespace ASP_Angular.Controllers.Resources
{
    public class VehicleResource {
        public int Id { get; set; }
        public KeyValuePareResource Model { get; set; }
        public KeyValuePareResource Make { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }
        public ContactResource Contact { get; set; }

        public ICollection<KeyValuePareResource> Features { get; set; }
        public VehicleResource () {
            Features = new Collection<KeyValuePareResource> ();
        }

    }
}
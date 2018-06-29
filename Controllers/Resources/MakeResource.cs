using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASP_Angular.Controllers.Resources
{
    public class MakeResource : KeyValuePareResource
    {
           
        public ICollection<KeyValuePareResource>  Models { get; set; }
        public MakeResource()
        {
            Models = new Collection<KeyValuePareResource>();
        }
    }
}